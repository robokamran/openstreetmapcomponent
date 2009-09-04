namespace OpenStreetMapSample
{
    partial class OpenStreetMapSample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenStreetMapSample));
            this.tbNWLngDeg = new System.Windows.Forms.TextBox();
            this.tbNWLatDeg = new System.Windows.Forms.TextBox();
            this.tbSELngDeg = new System.Windows.Forms.TextBox();
            this.tbSELatDeg = new System.Windows.Forms.TextBox();
            this.reloadMapButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNWLatMin = new System.Windows.Forms.TextBox();
            this.tbNWLngMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbSELatMin = new System.Windows.Forms.TextBox();
            this.tbSELngMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbClickedLat = new System.Windows.Forms.TextBox();
            this.tbClickedLng = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbPointedLat = new System.Windows.Forms.TextBox();
            this.tbPointedLng = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbSELat = new System.Windows.Forms.TextBox();
            this.tbSELng = new System.Windows.Forms.TextBox();
            this.tbNWLat = new System.Windows.Forms.TextBox();
            this.tbNWLng = new System.Windows.Forms.TextBox();
            this.tbZoom = new System.Windows.Forms.TextBox();
            this.openStreetMapViewer1 = new OpenStreetMap.OpenStreetMapViewer();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonTileManager = new System.Windows.Forms.Button();
            this.tbCacheDirectory = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbDataProvider = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbNWLngDeg
            // 
            this.tbNWLngDeg.Location = new System.Drawing.Point(37, 19);
            this.tbNWLngDeg.Name = "tbNWLngDeg";
            this.tbNWLngDeg.Size = new System.Drawing.Size(39, 20);
            this.tbNWLngDeg.TabIndex = 1;
            this.tbNWLngDeg.Text = "-180";
            // 
            // tbNWLatDeg
            // 
            this.tbNWLatDeg.Location = new System.Drawing.Point(37, 45);
            this.tbNWLatDeg.Name = "tbNWLatDeg";
            this.tbNWLatDeg.Size = new System.Drawing.Size(39, 20);
            this.tbNWLatDeg.TabIndex = 3;
            this.tbNWLatDeg.Text = "85";
            // 
            // tbSELngDeg
            // 
            this.tbSELngDeg.Location = new System.Drawing.Point(38, 19);
            this.tbSELngDeg.Name = "tbSELngDeg";
            this.tbSELngDeg.Size = new System.Drawing.Size(39, 20);
            this.tbSELngDeg.TabIndex = 5;
            this.tbSELngDeg.Text = "180";
            // 
            // tbSELatDeg
            // 
            this.tbSELatDeg.Location = new System.Drawing.Point(38, 45);
            this.tbSELatDeg.Name = "tbSELatDeg";
            this.tbSELatDeg.Size = new System.Drawing.Size(39, 20);
            this.tbSELatDeg.TabIndex = 7;
            this.tbSELatDeg.Text = "-85";
            // 
            // reloadMapButton
            // 
            this.reloadMapButton.Location = new System.Drawing.Point(683, 182);
            this.reloadMapButton.Name = "reloadMapButton";
            this.reloadMapButton.Size = new System.Drawing.Size(145, 23);
            this.reloadMapButton.TabIndex = 9;
            this.reloadMapButton.Text = "Set Area";
            this.reloadMapButton.UseVisualStyleBackColor = true;
            this.reloadMapButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbNWLatMin);
            this.groupBox1.Controls.Add(this.tbNWLngMin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbNWLngDeg);
            this.groupBox1.Controls.Add(this.tbNWLatDeg);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(682, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 79);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NW-Corner";
            // 
            // tbNWLatMin
            // 
            this.tbNWLatMin.Location = new System.Drawing.Point(86, 46);
            this.tbNWLatMin.Name = "tbNWLatMin";
            this.tbNWLatMin.Size = new System.Drawing.Size(43, 20);
            this.tbNWLatMin.TabIndex = 4;
            this.tbNWLatMin.Text = "00,000";
            // 
            // tbNWLngMin
            // 
            this.tbNWLngMin.Location = new System.Drawing.Point(85, 19);
            this.tbNWLngMin.Name = "tbNWLngMin";
            this.tbNWLngMin.Size = new System.Drawing.Size(44, 20);
            this.tbNWLngMin.TabIndex = 2;
            this.tbNWLngMin.Text = "00,000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "°";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Lat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Lng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(74, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "°";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbSELatMin);
            this.groupBox2.Controls.Add(this.tbSELngMin);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbSELngDeg);
            this.groupBox2.Controls.Add(this.tbSELatDeg);
            this.groupBox2.Location = new System.Drawing.Point(682, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 79);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SE-Corner";
            // 
            // tbSELatMin
            // 
            this.tbSELatMin.Location = new System.Drawing.Point(87, 44);
            this.tbSELatMin.Name = "tbSELatMin";
            this.tbSELatMin.Size = new System.Drawing.Size(43, 20);
            this.tbSELatMin.TabIndex = 8;
            this.tbSELatMin.Text = "00,000";
            // 
            // tbSELngMin
            // 
            this.tbSELngMin.Location = new System.Drawing.Point(87, 18);
            this.tbSELngMin.Name = "tbSELngMin";
            this.tbSELngMin.Size = new System.Drawing.Size(43, 20);
            this.tbSELngMin.TabIndex = 6;
            this.tbSELngMin.Text = "00,000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "°";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "°";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Lat";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Zoom level";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "NW";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "SE";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbClickedLat);
            this.groupBox3.Controls.Add(this.tbClickedLng);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.tbPointedLat);
            this.groupBox3.Controls.Add(this.tbPointedLng);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.tbSELat);
            this.groupBox3.Controls.Add(this.tbSELng);
            this.groupBox3.Controls.Add(this.tbNWLat);
            this.groupBox3.Controls.Add(this.tbNWLng);
            this.groupBox3.Controls.Add(this.tbZoom);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(146, 257);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Map statistics";
            // 
            // tbClickedLat
            // 
            this.tbClickedLat.Location = new System.Drawing.Point(71, 228);
            this.tbClickedLat.Name = "tbClickedLat";
            this.tbClickedLat.ReadOnly = true;
            this.tbClickedLat.Size = new System.Drawing.Size(58, 20);
            this.tbClickedLat.TabIndex = 22;
            this.tbClickedLat.TabStop = false;
            // 
            // tbClickedLng
            // 
            this.tbClickedLng.Location = new System.Drawing.Point(71, 202);
            this.tbClickedLng.Name = "tbClickedLng";
            this.tbClickedLng.ReadOnly = true;
            this.tbClickedLng.Size = new System.Drawing.Size(58, 20);
            this.tbClickedLng.TabIndex = 21;
            this.tbClickedLng.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 205);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Clicked";
            // 
            // tbPointedLat
            // 
            this.tbPointedLat.Location = new System.Drawing.Point(72, 176);
            this.tbPointedLat.Name = "tbPointedLat";
            this.tbPointedLat.ReadOnly = true;
            this.tbPointedLat.Size = new System.Drawing.Size(58, 20);
            this.tbPointedLat.TabIndex = 19;
            this.tbPointedLat.TabStop = false;
            // 
            // tbPointedLng
            // 
            this.tbPointedLng.Location = new System.Drawing.Point(72, 150);
            this.tbPointedLng.Name = "tbPointedLng";
            this.tbPointedLng.ReadOnly = true;
            this.tbPointedLng.Size = new System.Drawing.Size(58, 20);
            this.tbPointedLng.TabIndex = 18;
            this.tbPointedLng.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Pointed";
            // 
            // tbSELat
            // 
            this.tbSELat.Location = new System.Drawing.Point(72, 124);
            this.tbSELat.Name = "tbSELat";
            this.tbSELat.ReadOnly = true;
            this.tbSELat.Size = new System.Drawing.Size(58, 20);
            this.tbSELat.TabIndex = 16;
            this.tbSELat.TabStop = false;
            // 
            // tbSELng
            // 
            this.tbSELng.Location = new System.Drawing.Point(72, 98);
            this.tbSELng.Name = "tbSELng";
            this.tbSELng.ReadOnly = true;
            this.tbSELng.Size = new System.Drawing.Size(58, 20);
            this.tbSELng.TabIndex = 15;
            this.tbSELng.TabStop = false;
            // 
            // tbNWLat
            // 
            this.tbNWLat.Location = new System.Drawing.Point(72, 72);
            this.tbNWLat.Name = "tbNWLat";
            this.tbNWLat.ReadOnly = true;
            this.tbNWLat.Size = new System.Drawing.Size(58, 20);
            this.tbNWLat.TabIndex = 14;
            this.tbNWLat.TabStop = false;
            // 
            // tbNWLng
            // 
            this.tbNWLng.Location = new System.Drawing.Point(72, 46);
            this.tbNWLng.Name = "tbNWLng";
            this.tbNWLng.ReadOnly = true;
            this.tbNWLng.Size = new System.Drawing.Size(58, 20);
            this.tbNWLng.TabIndex = 13;
            this.tbNWLng.TabStop = false;
            // 
            // tbZoom
            // 
            this.tbZoom.Location = new System.Drawing.Point(72, 19);
            this.tbZoom.Name = "tbZoom";
            this.tbZoom.ReadOnly = true;
            this.tbZoom.Size = new System.Drawing.Size(58, 20);
            this.tbZoom.TabIndex = 12;
            this.tbZoom.TabStop = false;
            // 
            // openStreetMapViewer1
            // 
            this.openStreetMapViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.openStreetMapViewer1.Location = new System.Drawing.Point(164, 14);
            this.openStreetMapViewer1.MarkModifiers = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.openStreetMapViewer1.MoveModifiers = ((System.Windows.Forms.Keys)(System.Windows.Forms.Keys.None));
            this.openStreetMapViewer1.Name = "openStreetMapViewer1";
            this.openStreetMapViewer1.Size = new System.Drawing.Size(512, 512);
            this.openStreetMapViewer1.TabIndex = 0;
            this.openStreetMapViewer1.CoordinatePointed += new OpenStreetMap.OpenStreetMapViewer.CoordinateHandler(this.openStreetMapViewer1_CoordinatesPointed);
            this.openStreetMapViewer1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.openStreetMapViewer1_MouseDoubleClick);
            this.openStreetMapViewer1.DisplayedAreaChanged += new OpenStreetMap.OpenStreetMapViewer.CoordinatesZoomHandler(this.openStreetMapViewer1_DisplayedAreaChanged);
            this.openStreetMapViewer1.CoordinatesMarked += new OpenStreetMap.OpenStreetMapViewer.CoordinatesHandler(this.openStreetMapViewer1_CoordinatesMarked);
            this.openStreetMapViewer1.CoordinateClicked += new OpenStreetMap.OpenStreetMapViewer.CoordinateHandler(this.openStreetMapViewer1_CoordinatesClicked);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 275);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(145, 149);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "Coordinates have the\nfollowing sign:\npositive in N, E\nnegative in S, W\n\nDouble cl" +
                "ick zooms out\nLeft drag moves the map\nShift+Left click zooms into the marked are" +
                "a";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonTileManager);
            this.groupBox4.Controls.Add(this.tbCacheDirectory);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.tbDataProvider);
            this.groupBox4.Location = new System.Drawing.Point(683, 212);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(148, 162);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tile Manager";
            // 
            // buttonTileManager
            // 
            this.buttonTileManager.Location = new System.Drawing.Point(7, 125);
            this.buttonTileManager.Name = "buttonTileManager";
            this.buttonTileManager.Size = new System.Drawing.Size(135, 23);
            this.buttonTileManager.TabIndex = 12;
            this.buttonTileManager.Text = "Set TileManager";
            this.buttonTileManager.UseVisualStyleBackColor = true;
            this.buttonTileManager.Click += new System.EventHandler(this.buttonTileManager_Click);
            // 
            // tbCacheDirectory
            // 
            this.tbCacheDirectory.Location = new System.Drawing.Point(7, 98);
            this.tbCacheDirectory.Name = "tbCacheDirectory";
            this.tbCacheDirectory.Size = new System.Drawing.Size(135, 20);
            this.tbCacheDirectory.TabIndex = 11;
            this.tbCacheDirectory.Text = "Cache";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "CacheDirectory";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Dataprovider";
            // 
            // tbDataProvider
            // 
            this.tbDataProvider.Location = new System.Drawing.Point(6, 36);
            this.tbDataProvider.Multiline = true;
            this.tbDataProvider.Name = "tbDataProvider";
            this.tbDataProvider.Size = new System.Drawing.Size(136, 38);
            this.tbDataProvider.TabIndex = 10;
            this.tbDataProvider.Text = "http://tile.openstreetmap.org/";
            // 
            // OpenStreetMapSample
            // 
            this.AcceptButton = this.reloadMapButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 536);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reloadMapButton);
            this.Controls.Add(this.openStreetMapViewer1);
            this.Name = "OpenStreetMapSample";
            this.Text = "OpenStreetMapSample";
            this.Load += new System.EventHandler(this.OpenStreetMapSample_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenStreetMap.OpenStreetMapViewer openStreetMapViewer1;
        private System.Windows.Forms.TextBox tbNWLngDeg;
        private System.Windows.Forms.TextBox tbNWLatDeg;
        private System.Windows.Forms.TextBox tbSELngDeg;
        private System.Windows.Forms.TextBox tbSELatDeg;
        private System.Windows.Forms.Button reloadMapButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNWLatMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbNWLngMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSELatMin;
        private System.Windows.Forms.TextBox tbSELngMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbNWLng;
        private System.Windows.Forms.TextBox tbZoom;
        private System.Windows.Forms.TextBox tbSELat;
        private System.Windows.Forms.TextBox tbSELng;
        private System.Windows.Forms.TextBox tbNWLat;
        private System.Windows.Forms.TextBox tbClickedLat;
        private System.Windows.Forms.TextBox tbClickedLng;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbPointedLat;
        private System.Windows.Forms.TextBox tbPointedLng;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonTileManager;
        private System.Windows.Forms.TextBox tbCacheDirectory;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbDataProvider;
    }
}