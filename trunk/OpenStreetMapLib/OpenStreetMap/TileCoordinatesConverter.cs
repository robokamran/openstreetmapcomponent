using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OpenStreetMap
{
    /// <summary>
    /// Static class with convert functions between tile and world coordinates
    /// </summary>
    static class TileCoordinatesConverter
    {
        /// <summary>
        /// Returns the tile coordinates for world coordinates
        /// Thanks to http://wiki.openstreetmap.org/wiki/Slippy_map_tilenames#C.23
        /// </summary>
        /// <param name="zoom"></param>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public static PointF GetTileIndex(int zoom, PointF coordinates)
        {
            float x = Convert.ToSingle((coordinates.X + 180.0) / 360.0 * (1 << zoom));
            float y = Convert.ToSingle(((1.0 - Math.Log(Math.Tan(coordinates.Y * Math.PI / 180.0) + 1.0 / Math.Cos(coordinates.Y * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom)));
            return new PointF(x, y);
        }

        /// <summary>
        /// Returns the world coordinates for tile coordinates
        /// Thanks to http://wiki.openstreetmap.org/wiki/Slippy_map_tilenames#C.23
        /// </summary>
        /// <param name="zoom"></param>
        /// <param name="tileIndex"></param>
        /// <returns></returns>
        public static PointF GetCoordinates(int zoom, PointF tileIndex)
        {
            PointF p = new Point();
            double n = Math.PI - ((2.0 * Math.PI * tileIndex.Y) / Math.Pow(2.0, zoom));

            p.X = (float)((tileIndex.X / Math.Pow(2.0, zoom) * 360.0) - 180.0);
            p.Y = (float)(180.0 / Math.PI * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n))));

            return p;
        }
    }
}
