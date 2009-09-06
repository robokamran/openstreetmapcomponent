using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OpenStreetMap
{
    /// <summary>
    /// Contains all information about a single tile.
    /// 
    /// Written by Florian Beer
    /// Project homepage: http://code.google.com/p/openstreetmapcomponent
    /// </summary>
    class Tile
    {
        private int x;
        /// <summary>
        /// The index of the tile in W-E direction
        /// </summary>
        public int X
        {
            get { return x; }
        }

        private int y;
        /// <summary>
        /// The index of the tile in N-S direction
        /// </summary>
        public int Y
        {
            get { return y; }
        }

        private int zoom;
        /// <summary>
        /// The zoom level of the tile
        /// </summary>
        public int Zoom
        {
            get { return zoom; }
        }

        private Bitmap picture;
        /// <summary>
        /// The tile data
        /// </summary>
        public Bitmap Picture
        {
            get { return picture; }
        }

        /// <summary>
        /// Constructor setting all data of the tile
        /// </summary>
        /// <param name="zoom"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="picture"></param>
        public Tile(int zoom, int x, int y, Bitmap picture)
        {
            this.zoom = zoom;
            this.x = x;
            this.y = y;
            this.picture = picture;
        }
    }
}
