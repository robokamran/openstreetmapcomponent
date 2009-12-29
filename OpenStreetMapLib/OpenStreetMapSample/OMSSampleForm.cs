using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenStreetMap;

namespace OpenStreetMapSample
{
    /// <summary>
    /// A sample implementation showing the features of the OpenStreetMapViewer component
    /// 
    /// Written by Florian Beer
    /// Project homepage: http://code.google.com/p/openstreetmapcomponent
    /// </summary>
    public partial class OpenStreetMapSample : Form
    {
        /// <summary>
        /// Constructor, initializes the component
        /// </summary>
        public OpenStreetMapSample()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointF NWCoord = new PointF();
            NWCoord.X = float.Parse(tbNWLngDeg.Text);
            if(NWCoord.X>0)
                NWCoord.X += float.Parse(tbNWLngMin.Text) / 60.0f;
            else
                NWCoord.X -= float.Parse(tbNWLngMin.Text) / 60.0f;
            NWCoord.Y = float.Parse(tbNWLatDeg.Text);
            if (NWCoord.Y > 0)
                NWCoord.Y += float.Parse(tbNWLatMin.Text) / 60.0f;
            else
                NWCoord.Y -= float.Parse(tbNWLatMin.Text) / 60.0f;

            PointF SECoord = new PointF();
            SECoord.X = float.Parse(tbSELngDeg.Text);
            if(SECoord.X>0)
                SECoord.X += float.Parse(tbSELngMin.Text) / 60.0f;
            else
                SECoord.X -= float.Parse(tbSELngMin.Text) / 60.0f;
            SECoord.Y = float.Parse(tbSELatDeg.Text);
            if(SECoord.Y>0)
                SECoord.Y += float.Parse(tbSELatMin.Text) / 60.0f;
            else
                SECoord.Y -= float.Parse(tbSELatMin.Text) / 60.0f;

            openStreetMapViewer1.TopLeftCoord = NWCoord;
            openStreetMapViewer1.BottomRightCoord = SECoord;
        }

        private void UpdateMapStatistic()
        {
            tbZoom.Text = openStreetMapViewer1.Zoom.ToString();
            tbNWLng.Text = openStreetMapViewer1.TopLeftDisplay.X.ToString();
            tbNWLat.Text = openStreetMapViewer1.TopLeftDisplay.Y.ToString();
            tbSELng.Text = openStreetMapViewer1.BottomRightDisplay.X.ToString();
            tbSELat.Text = openStreetMapViewer1.BottomRightDisplay.Y.ToString();
        }

        private void OpenStreetMapSample_Load(object sender, EventArgs e)
        {
            openStreetMapViewer1.CenterCoord = new PointF(0, 0);
            openStreetMapViewer1.Zoom = 1;
            UpdateMapStatistic();
            openStreetMapViewer1.ClearPolygons();
            openStreetMapViewer1.PolygonPen = Pens.Red;
            openStreetMapViewer1.AddPolygon(new PointF[] { new PointF(10.0f, -10.0f), new PointF(-10.0f, -10.0f), new PointF(-10.0f, 10.0f), new PointF(10.0f, 10.0f) });
        }

        private void openStreetMapViewer1_CoordinatesClicked(PointF coord)
        {
            tbClickedLng.Text = coord.X.ToString();
            tbClickedLat.Text = coord.Y.ToString();
        }

        private void openStreetMapViewer1_CoordinatesPointed(PointF coord)
        {
            tbPointedLng.Text = coord.X.ToString();
            tbPointedLat.Text = coord.Y.ToString();
        }

        private void openStreetMapViewer1_CoordinatesMarked(PointF coord1, PointF coord2)
        {
        }

        private void openStreetMapViewer1_DisplayedAreaChanged(PointF coord1, PointF coord2, int zoom)
        {
            tbZoom.Text = zoom.ToString();
            tbNWLng.Text = coord1.X.ToString();
            tbNWLat.Text = coord1.Y.ToString();
            tbSELng.Text = coord2.X.ToString();
            tbSELat.Text = coord2.Y.ToString();
        }

        private void buttonTileManager_Click(object sender, EventArgs e)
        {
            openStreetMapViewer1.SetDataProvider(tbDataProvider.Text, tbCacheDirectory.Text);
        }

        private void openStreetMapViewer1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OverlayItem item = new OverlayItem();
            item.Coord = new PointF(float.Parse(tbClickedLng.Text), float.Parse(tbClickedLat.Text));
            Bitmap b = new Bitmap(64, 64);
            Graphics g = Graphics.FromImage(b);
            Pen pen = new Pen(Color.Black, 3.0f);
            g.Clear(BackColor);
            g.DrawLine(pen, new Point(1, 1), new Point(62, 1));
            g.DrawLine(pen, new Point(1, 1), new Point(31, 62));
            g.DrawLine(pen, new Point(62, 1), new Point(31, 62));
            g.Dispose();
            item.Icon = b;
            item.Offset = new Point(31,64);
            item.ToolTip = "Test";
            item.Transparent = BackColor;
            openStreetMapViewer1.AddOverlayItem(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openStreetMapViewer1.ClearOverlayItems();
        }
    }
}