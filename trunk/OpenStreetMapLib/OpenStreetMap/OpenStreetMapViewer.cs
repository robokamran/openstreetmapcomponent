using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Drawing.Imaging;
using System.Net.Cache;
using QuickZip.MiniHtml.Controls;

namespace OpenStreetMap
{
    /// <summary>
    /// A Control for displaying and navigating in the OpenStreetMap
    /// 
    /// Written by Florian Beer
    /// Project homepage: http://code.google.com/p/openstreetmapcomponent
    /// </summary>
    public partial class OpenStreetMapViewer : UserControl
    {
        private enum ActionType
        {
            none,
            move,
            mark
        }

        #region Properties
        /// <summary>
        /// MarkModifiers have to be pressed that marking a area, while holding the left mouse button pressed, will work
        /// </summary>
        public Keys MarkModifiers
        {
            get { return markModifiers; }
            set { markModifiers = value; }
        }
        /// <summary>
        /// MoveModifiers have to be pressed that moving the viewport with dragging with the left mouse button pressed, will work
        /// </summary>
        public Keys MoveModifiers
        {
            get { return moveModifiers; }
            set { moveModifiers = value; }
        }

        /// <summary>
        /// Sets and gets the wanted coordinates of the top left corner
        /// </summary>
        public PointF TopLeftCoord
        {
            private get { return topLeftCoord; }
            set
            {
                topLeftCoord = value;
                CenterCoord = new PointF((topLeftCoord.X + BottomRightCoord.X) / 2.0f, (topLeftCoord.Y + BottomRightCoord.Y) / 2.0f);
                Zoom = tileManager.GetOptimalZoomLevel(this.Size, TopLeftCoord, BottomRightCoord);
            }
        }
        /// <summary>
        /// Sets and gets the wanted coordinates of the bottom right corner
        /// </summary>
        public PointF BottomRightCoord
        {
            private get { return bottomRightCoord; }
            set
            {
                bottomRightCoord = value;
                CenterCoord = new PointF((topLeftCoord.X + BottomRightCoord.X) / 2.0f, (topLeftCoord.Y + BottomRightCoord.Y) / 2.0f);
                Zoom = tileManager.GetOptimalZoomLevel(this.Size, TopLeftCoord, BottomRightCoord);
            }
        }

        /// <summary>
        /// Sets and gets the center point
        /// </summary>
        public PointF CenterCoord
        {
            get { return centerCoord; }
            set
            {
                centerCoord = value;
                renderMap();
            }
        }
        /// <summary>
        /// Sets and gets the actual zoom level
        /// </summary>
        public int Zoom
        {
            get { return zoom; }
            set
            {
                zoom = value < tileManager.MinZoom ? tileManager.MinZoom : (value > tileManager.MaxZoom ? tileManager.MaxZoom : value);
                renderMap();
            }
        }

        /// <summary>
        /// Gets the actual coordinates of the top left corner
        /// </summary>
        public PointF TopLeftDisplay
        {
            get { return TileCoordinatesConverter.GetCoordinates(zoom, topLeftTile); }
        }
        /// <summary>
        /// Gets the actual coordinates of the bottom right corner
        /// </summary>
        public PointF BottomRightDisplay
        {
            get { return TileCoordinatesConverter.GetCoordinates(zoom, bottomRightTile); }
        }

        /// <summary>
        /// Gets the dataProvider for the tiles, default is http://tile.openstreetmap.org/
        /// </summary>
        public string DataProvider
        {
            get { return tileManager.DataProvider; }
        }
        /// <summary>
        /// Gets the cache directory for the TileManager, use different caches for di
        /// </summary>
        public string CacheDirectory
        {
            get { return tileManager.CacheDirectory; }
        }

        /// <summary>
        /// Gets and sets the ccs for the tooltips
        /// </summary>
        public string CSS
        {
            get { return css; }
            set { css = value; }
        }

        /// <summary>
        /// Gets and sets the pen used for painting the polygons
        /// </summary>
        public Pen PolygonPen
        {
            get { return polygonPen; }
            set { polygonPen = value; }
        }
        #endregion

        #region events
        /// <summary>
        /// Event handler for one coordinate
        /// </summary>
        /// <param name="coord"></param>
        public delegate void CoordinateHandler(PointF coord);
        /// <summary>
        /// Event handler for two coordinates
        /// </summary>
        /// <param name="coord1"></param>
        /// <param name="coord2"></param>
        public delegate void CoordinatesHandler(PointF coord1, PointF coord2);
        /// <summary>
        /// Event handler for two coordinates and zoom level
        /// </summary>
        /// <param name="coord1"></param>
        /// <param name="coord2"></param>
        /// <param name="zoom"></param>
        public delegate void CoordinatesZoomHandler(PointF coord1, PointF coord2, int zoom);
        /// <summary>
        /// Event is thrown, when a coordinate is pointed with the mouse
        /// </summary>
        public event CoordinateHandler CoordinatePointed;
        /// <summary>
        /// Event is thrown, when a coordinate is clicked with the mouse
        /// </summary>
        public event CoordinateHandler CoordinateClicked;
        /// <summary>
        /// Event is thrown, when the user marked a area with the mouse
        /// coord1 is top left corner, coord2 is bottom right corner
        /// </summary>
        public event CoordinatesHandler CoordinatesMarked;
        /// <summary>
        /// Event is thrown, when the displayed area has changed
        /// coord1 is top left corner, coord2 is bottom right corner
        /// </summary>
        public event CoordinatesZoomHandler DisplayedAreaChanged;
        #endregion

        #region event methods
        private void coordinatePointed(PointF coord)
        {
            if (CoordinatePointed != null)
                CoordinatePointed(coord);
        }
        private void coordinateClicked(PointF coord)
        {
            if (CoordinateClicked != null)
                CoordinateClicked(coord);
        }
        private void coordinatesMarked(PointF coord1, PointF coord2)
        {
            if (CoordinatesMarked != null)
                CoordinatesMarked(coord1, coord2);
        }
        private void displayedAreaChanged(PointF coord1, PointF coord2, int zoom)
        {
            if (DisplayedAreaChanged != null)
                DisplayedAreaChanged(coord1, coord2, zoom);
        }
        #endregion

        #region private members
        PointF centerCoord = new PointF(0.0f, 0.0f);
        int zoom = 0;

        List<OverlayItem> overlayItems = new List<OverlayItem>();
        List<PointF[]> polygonItems = new List<PointF[]>();

        PointF topLeftCoord = new PointF(-179, 85);
        PointF bottomRightCoord = new PointF(179, -85);
        PointF topLeftTile = new PointF(0, 0);
        PointF bottomRightTile = new PointF(0, 0);
        Bitmap bitmap = null;
        PointF lastClickedCoord = new PointF();
        Point lastMouseClick = new Point();
        Point actMousePosition = new Point();
        ActionType startedAction = ActionType.none;
        Keys markModifiers = Keys.Shift;
        Keys moveModifiers = Keys.None;
        TileManager tileManager = new TileManager("http://tile.openstreetmap.org/", "Cache");
        mhLabel toolTip = null;
        string css = "";
        Pen polygonPen = Pens.Red;
        #endregion

        /// <summary>
        /// Initializes the component
        /// </summary>
        public OpenStreetMapViewer()
        {
            InitializeComponent();
            linkLabelCC.Links.Add(0, linkLabelCC.Text.Length, "http://creativecommons.org/licenses/by-sa/2.0/");
            linkLabelOMS.Links.Add(0, linkLabelOMS.Text.Length, "http://www.openstreetmap.org/");
            this.MouseWheel += new MouseEventHandler(OpenStreetMapViewer_MouseWheel);
        }

        #region public methods
        /// <summary>
        /// Creates a new TileManager with the given data provider and cache directory
        /// </summary>
        /// <param name="dataProvider"></param>
        /// <param name="cacheDirectory"></param>
        public void SetDataProvider(string dataProvider, string cacheDirectory)
        {
            tileManager = new TileManager(dataProvider, cacheDirectory);
            renderMap();
        }

        public void ClearPolygons()
        {
            polygonItems.Clear();
            renderMap();
        }

        /// <summary>
        /// Removes all overlay items
        /// </summary>
        public void ClearOverlayItems()
        {
            overlayItems.Clear();
            renderMap();
        }

        public void AddPolygon(PointF[] polygon)
        {
            if (polygon == null)
                return;
            polygonItems.Add(polygon);
            renderMap();
        }

        /// <summary>
        /// Adds an overlay item
        /// </summary>
        /// <param name="item"></param>
        public void AddOverlayItem(OverlayItem item)
        {
            if (item == null)
                return;
            overlayItems.Add(item);
            renderMap();
        }

        /// <summary>
        /// Removes the given overlay item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool RemoveOverlayItem(OverlayItem item)
        {
            return overlayItems.Remove(item);
        }
        #endregion

        #region private methods
        private void renderMap()
        {
            //calculating viewport
            PointF centerTile = TileCoordinatesConverter.GetTileIndex(Zoom, CenterCoord);
            SizeF viewportSizeInTiles = new SizeF((float)Size.Width / (float)tileManager.TileSize.Width, (float)Size.Height / (float)tileManager.TileSize.Height);

            topLeftTile = new PointF(centerTile.X - viewportSizeInTiles.Width / 2.0f, centerTile.Y - viewportSizeInTiles.Height / 2.0f);
            bottomRightTile = new PointF(centerTile.X + viewportSizeInTiles.Width / 2.0f, centerTile.Y + viewportSizeInTiles.Height / 2.0f);

            //generate bitmap with tiles
            bitmap = new Bitmap(Size.Width, Size.Height);
            Graphics g = Graphics.FromImage(bitmap);
            for (int x = roundDownCoordinates(topLeftTile).X; x <= roundDownCoordinates(bottomRightTile).X; x++)
                for (int y = roundDownCoordinates(topLeftTile).Y; y <= roundDownCoordinates(bottomRightTile).Y; y++)
                {
                    Tile tile = tileManager.GetTile(zoom, x, y);
                    if (tile != null)
                        g.DrawImageUnscaled(tile.Picture, getLocationForTileIndex(tile.X, tile.Y));
                }
            //render overlay items
            foreach (OverlayItem item in overlayItems)
            {
                if (item.Icon != null)
                {
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetColorKey(item.Transparent, item.Transparent);
                    Point loc = getLocationForCoordinates(item.Coord);
                    loc.X -= item.Offset.X;
                    loc.Y -= item.Offset.Y;
                    Rectangle destRect = new Rectangle(loc, item.Icon.Size);
                    g.DrawImage(item.Icon, destRect, 0, 0, item.Icon.Size.Width, item.Icon.Size.Height, GraphicsUnit.Pixel, attr);
                }
            }
            //render polygons
            foreach (PointF[] pointArray in polygonItems)
            {
                List<Point> locArray = new List<Point>();
                foreach(PointF p in pointArray)
                    locArray.Add(getLocationForCoordinates(p));
                g.DrawPolygon(polygonPen, locArray.ToArray());
            }

            g.Dispose();
            this.Invalidate();
            displayedAreaChanged(TopLeftDisplay, BottomRightDisplay, Zoom);
        }

        private Point getLocationForTileIndex(float x, float y)
        {
            float offsetTileX = x - topLeftTile.X;
            float offsetTileY = y - topLeftTile.Y;
            int offsetX = (int)Math.Round(offsetTileX * tileManager.TileSize.Width);
            int offsetY = (int)Math.Round(offsetTileY * tileManager.TileSize.Height);
            return new Point(offsetX, offsetY);
        }

        private Point getLocationForCoordinates(PointF coord)
        {
            PointF tileIndex = TileCoordinatesConverter.GetTileIndex(Zoom, coord);
            return getLocationForTileIndex(tileIndex.X, tileIndex.Y);
        }

        private Point roundDownCoordinates(PointF point)
        {
            Point p = new Point();
            p.X = Convert.ToInt32(Math.Floor(point.X));
            p.Y = Convert.ToInt32(Math.Floor(point.Y));
            return p;
        }

        private PointF getTileCoordinatesFromLocation(Point location)
        {
            return new PointF((float)location.X / (float)tileManager.TileSize.Width + topLeftTile.X, (float)location.Y / (float)tileManager.TileSize.Height + topLeftTile.Y);
        }
        #endregion

        #region private event handlers
        private void OpenStreetMapViewer_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
                if (startedAction == ActionType.move)
                    e.Graphics.DrawLine(Pens.Black, lastMouseClick, actMousePosition);
                if (startedAction == ActionType.mark)
                {
                    Rectangle r = new Rectangle();
                    r.Location = new Point(Math.Min(lastMouseClick.X, actMousePosition.X), Math.Min(lastMouseClick.Y, actMousePosition.Y));
                    r.Width = Math.Abs(lastMouseClick.X - actMousePosition.X);
                    r.Height = Math.Abs(lastMouseClick.Y - actMousePosition.Y);
                    e.Graphics.DrawRectangle(Pens.Black, r);
                }
            }
            catch { }
        }

        private void OpenStreetMapViewer_MouseMove(object sender, MouseEventArgs e)
        {
            // pointed coordinate
            PointF pointTile = new PointF((float)e.X / (float)tileManager.TileSize.Width + topLeftTile.X, (float)e.Y / (float)tileManager.TileSize.Height + topLeftTile.Y);
            coordinatePointed(TileCoordinatesConverter.GetCoordinates(zoom, pointTile));
            actMousePosition = e.Location;

            //tooltip hide/ show
            if (toolTip != null)
            {
                if (e.X < toolTip.Left || e.X > toolTip.Right || e.Y < toolTip.Top || e.Y > toolTip.Bottom)
                    removeToolTip();
            }
            else if(startedAction== ActionType.none)
            {
                int offset = 5;
                foreach (OverlayItem item in overlayItems)
                {
                    Point loc = getLocationForCoordinates(item.Coord);
                    if (loc.X >= e.X - offset &&
                        loc.X <= e.X + offset &&
                        loc.Y >= e.Y - offset &&
                        loc.Y <= e.Y + offset)
                    {
                        addToolTip(loc, item.ToolTip);
                        break;
                    }
                }
            }

            // repaint
            if(startedAction != ActionType.none)
                Invalidate();
        }

        private void OpenStreetMapViewer_MouseClick(object sender, MouseEventArgs e)
        {
            coordinateClicked(TileCoordinatesConverter.GetCoordinates(zoom, getTileCoordinatesFromLocation(e.Location)));
        }

        private void OpenStreetMapViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (startedAction == ActionType.none && e.Button == MouseButtons.Left)
            {
                lastClickedCoord = TileCoordinatesConverter.GetCoordinates(zoom, getTileCoordinatesFromLocation(e.Location));
                lastMouseClick = e.Location;
                if (ModifierKeys == markModifiers)
                    startedAction = ActionType.mark;
                else if (ModifierKeys == moveModifiers)
                    startedAction = ActionType.move;
                else
                    startedAction = ActionType.none;
            }
            else
                startedAction = ActionType.none;
        }

        private void OpenStreetMapViewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (startedAction == ActionType.mark && ModifierKeys==markModifiers)
                {
                    PointF pointTile = TileCoordinatesConverter.GetCoordinates(zoom, getTileCoordinatesFromLocation(e.Location));
                    float xMin = Math.Min(lastClickedCoord.X, pointTile.X);
                    float xMax = Math.Max(lastClickedCoord.X, pointTile.X);
                    float yMin = Math.Min(lastClickedCoord.Y, pointTile.Y);
                    float yMax = Math.Max(lastClickedCoord.Y, pointTile.Y);
                    TopLeftCoord = new PointF(xMin, yMax);
                    BottomRightCoord = new PointF(xMax, yMin);
                    coordinatesMarked(new PointF(xMin, yMax), new PointF(xMax, yMin));
                }
                if (startedAction == ActionType.move && ModifierKeys == moveModifiers)
                {
                    PointF pointTile = TileCoordinatesConverter.GetCoordinates(zoom, getTileCoordinatesFromLocation(e.Location));
                    PointF diff = new PointF(lastClickedCoord.X - pointTile.X, lastClickedCoord.Y - pointTile.Y);
                    CenterCoord = new PointF(CenterCoord.X + diff.X, CenterCoord.Y + diff.Y);
                }
            }
            startedAction = ActionType.none;
        }

        private void linkLabelOMS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void linkLabelCC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        void OpenStreetMapViewer_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                Zoom += 1;
                CenterCoord = TileCoordinatesConverter.GetCoordinates(zoom, getTileCoordinatesFromLocation(e.Location));
            }
            if (e.Delta < 0)
                Zoom -= 1;
        }

        private void addToolTip(Point location, string hint)
        {
            if (toolTip != null)
                return;
            toolTip = new mhLabel();
            toolTip.Size = new Size(150, 40);
            toolTip.Location = new Point(location.X - toolTip.Width / 2, location.Y - toolTip.Height / 2);
            toolTip.BorderStyle = BorderStyle.Fixed3D;
            toolTip.Html = hint;
            toolTip.Css = CSS;
            this.Controls.Add(toolTip);
        }

        private void removeToolTip()
        {
            if (toolTip == null)
                return;
            this.Controls.Remove(toolTip);
            toolTip.Dispose();
            toolTip = null;
        }
        #endregion
    }
}