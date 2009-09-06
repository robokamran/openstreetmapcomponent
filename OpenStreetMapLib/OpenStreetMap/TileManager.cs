using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Net;
using System.Net.Cache;
using System.IO;

namespace OpenStreetMap
{
    /// <summary>
    /// The TileManager downloads, caches and returns tiles for given zoom and coordinates
    /// 
    /// Written by Florian Beer
    /// Project homepage: http://code.google.com/p/openstreetmapcomponent
    /// </summary>
    class TileManager
    {
        private string cacheDirectory = "Cache";
        public string CacheDirectory
        {
            get { return cacheDirectory; }
        }
        private string dataProvider = "http://localhost";
        public string DataProvider
        {
            get { return dataProvider; }
        }
        private int minZoom = 1;
        /// <summary>
        /// Sets and gets the minimum zoom level
        /// </summary>
        public int MinZoom
        {
            get { return minZoom; }
            set { minZoom = value; }
        }
        private int maxZoom = 17;
        /// <summary>
        /// Sets and gets the maximum zoom level
        /// </summary>
        public int MaxZoom
        {
            get { return maxZoom; }
            set { maxZoom = value; }
        }
        Dictionary<int, Dictionary<int, Dictionary<int, Bitmap>>> tiles = new Dictionary<int, Dictionary<int, Dictionary<int, Bitmap>>>();

        /// <summary>
        /// Initializes a TileManager with a dataProvider and a cacheDirectory
        /// </summary>
        /// <param name="dataProvider"></param>
        /// <param name="cacheDirectory"></param>
        public TileManager(string dataProvider, string cacheDirectory)
        {
            this.cacheDirectory = cacheDirectory.TrimEnd(new char[] { '\\' });
            this.dataProvider = dataProvider.TrimEnd(new char[] { '/' }) + "/";
        }

        private Size tileSize = new Size(256, 256);
        /// <summary>
        /// Returns the size of one tile
        /// </summary>
        public Size TileSize
        {
            get { return tileSize; }
        }

        /// <summary>
        /// Downloads, caches and creates tiles for given parameters.
        /// </summary>
        /// <param name="zoom"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Tile GetTile(int zoom, int x, int y)
        {
            if (x < 0 || x >= Math.Pow(2, zoom) || y < 0 || y >= Math.Pow(2, zoom))
                return null;
            if (!tileInCache(zoom, x, y))
                downloadTile(zoom, x, y);
            Bitmap tile = getTileFromCache(zoom, x, y);
            return tile == null ? null : new Tile(zoom, x, y, tile);
        }

        /// <summary>
        /// Calculates the maximum zoom level, with which both coordinates still fit into the given size
        /// </summary>
        /// <param name="size"></param>
        /// <param name="topLeft"></param>
        /// <param name="bottomRight"></param>
        /// <returns></returns>
        public int GetOptimalZoomLevel(Size size, PointF topLeft, PointF bottomRight)
        {
            double xTiles = Convert.ToDouble(size.Width) / Convert.ToDouble(TileSize.Width);
            double xDistance = bottomRight.X - topLeft.X;

            double yTiles = Convert.ToDouble(size.Height) / Convert.ToDouble(TileSize.Height);
            double yDistance = topLeft.Y - bottomRight.Y;

            double distancePerTile = Math.Max((xDistance / xTiles), (yDistance / yTiles));

            int zoom = 0;
            try
            {
                zoom = Convert.ToInt32(Math.Floor((Math.Log(360.0 / distancePerTile, 2.0)))); // distancePerTile=(360°/2^Zoom), we round down, to fit all
            }
            catch (OverflowException)
            {
                zoom = 100;
            }
            zoom = (zoom < minZoom) ? minZoom : zoom;   // minimal zoom is 1
            zoom = (zoom > maxZoom) ? maxZoom : zoom;  // maximal zoom for osmarender is 17

            return zoom;
        }

        #region private methods
        private bool tileInCache(int zoom, int x, int y)
        {
            //in memory
            if(tiles.ContainsKey(zoom) && tiles[zoom].ContainsKey(x) && tiles[zoom][x].ContainsKey(y))
                return true;

            //in disk cache
            return loadTileIntoMemCache(zoom, x, y);
        }

        private bool loadTileIntoMemCache(int zoom, int x, int y)
        {
            if (File.Exists(getFilename(zoom, x, y)))
            {
                try
                {
                    Bitmap b = new Bitmap(getFilename(zoom, x, y));
                    saveTile(zoom, x, y, b);
                    return true;
                }
                catch
                {
                    //if we can't load the file, we delete it
                    File.Delete(getFilename(zoom, x, y));
                    return false;
                }
            }
            return false;
        }

        private void downloadTile(int zoom, int x, int y)
        {
            //if we already have it in cache, don't download again
            if (tileInCache(zoom, x, y))
                return;

            if (x < 0 || x >= Math.Pow(2, zoom) || y < 0 || y >= Math.Pow(2, zoom))
                return;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.dataProvider + zoom.ToString() + "/" + x.ToString() + "/" + y.ToString() + ".png");
                request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (!Directory.Exists(cacheDirectory))
                    Directory.CreateDirectory(cacheDirectory);
                Bitmap b = new Bitmap(response.GetResponseStream());
                b.Save(getFilename(zoom, x, y));
                loadTileIntoMemCache(zoom, x, y);
            }
            catch { }
        }

        private void saveTile(int zoom, int x, int y, Bitmap b)
        {
            if (!tiles.ContainsKey(zoom))
                tiles[zoom] = new Dictionary<int, Dictionary<int, Bitmap>>();
            if (!tiles[zoom].ContainsKey(x))
                tiles[zoom][x] = new Dictionary<int, Bitmap>();
            tiles[zoom][x][y] = b;
        }

        private String getFilename(int zoom, int x, int y)
        {
            return cacheDirectory + "\\" + zoom.ToString() + "_" + x.ToString() + "_" + y.ToString() + ".png";
        }

        private Bitmap getTileFromCache(int zoom, int x, int y)
        {
            if (!tiles.ContainsKey(zoom))
                return null;
            if (!tiles[zoom].ContainsKey(x))
                return null;
            if (!tiles[zoom][x].ContainsKey(y))
                return null;
            return tiles[zoom][x][y];
        }
        #endregion
    }
}
