# Introduction #
Here is shown a short overview of the usage of the OpenStreepMapViewer component and it's structure

# Quickstart instructions #
```
private OpenStreetMap.OpenStreetMapViewer openStreetMapViewer1;

private void Inititalize()
{
    this.openStreetMapViewer1 = new OpenStreetMap.OpenStreetMapViewer();
    this.openStreetMapViewer1.Location = new Point(164, 14);
    this.openStreetMapViewer1.Size = new Size(512, 512);

    // Set center and zoomlevel
    this.openStreetMapViewer1.CenterCoord = new PointF(0,0);
    this.openStreetMapViewer1.Zoom = 1;

    //register event handlers
    this.openStreetMapViewer1.CoordinatePointed += new OpenStreetMap.OpenStreetMapViewer.CoordinateHandler(coordinatePointed);
    this.openStreetMapViewer1.CoordinateClicked += new OpenStreetMap.OpenStreetMapViewer.CoordinateHandler(coordinateClicked);
    this.openStreetMapViewer1.CoordinatesMarked += new OpenStreetMap.OpenStreetMapViewer.CoordinatesHandler(coordinatesMarked);
    this.openStreetMapViewer1.DisplayedAreaChanged += new OpenStreetMap.OpenStreetMapViewer.CoordinatesZoomHandler(displayedAreaChanged);

    //create and add an overlay item
    OverlayItem item = new OverlayItem();
    item.Coord = new PointF(0.0f, 0.0f);
    item.Icon = new Bitmap("icon.png");
    item.Offset = new Point(31,64); //offset of the tip of the arrow in the icon
    item.ToolTip = "Test";
    item.Transparent = BackColor; // color in the icon, which should be interpreted as transparent
    openStreetMapViewer1.AddOverlayItem(item);
}

//Pointed coordinate as parameter
private void coordinatePointed(PointF coord)
{ }

//Clicked coordinate as parameter
private void coordinatePointed(PointF coord)
{ }

//Marked area in parameters
private void coordinatesMarked(PointF topLeftCorner, PointF bottomRightCorner)
{ }

//New displayed area and zoom level
private void coordinatePointed(PointF topLeftCorner, PointF bottomRightCorner, int zoom)
{ }

```

# Structure overview #