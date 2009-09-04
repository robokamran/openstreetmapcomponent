using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace OpenStreetMap
{
    /// <summary>
    /// Overlay item is a class for waypoints, POIs
    /// </summary>
    public class OverlayItem
    {
        string toolTip = null;
        /// <summary>
        /// Sets and gets the tooltip, which is shown when mouse is over the item.
        /// ToolTip is interpreted as html
        /// </summary>
        public string ToolTip
        {
            get { return toolTip; }
            set { toolTip = value; }
        }

        PointF coord = new PointF();
        /// <summary>
        /// Coordinates, where item should be displayed
        /// </summary>
        public PointF Coord
        {
            get { return coord; }
            set { coord = value; }
        }

        Point offset = new Point();
        /// <summary>
        /// Sets the offset of the tip in the icon
        /// </summary>
        public Point Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        Image icon = null;
        /// <summary>
        /// Sets the icon of the item
        /// </summary>
        public Image Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        Color transparent = Color.Transparent;
        /// <summary>
        /// This color is used as transparent color
        /// </summary>
        public Color Transparent
        {
            get { return transparent; }
            set { transparent = value; }
        }
    }
}
