using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenStreetMapSample
{
    /// <summary>
    /// A sample implementation showing the features of the OpenStreetMapViewer component
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
    }
}