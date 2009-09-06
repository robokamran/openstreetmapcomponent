namespace OpenStreetMap
{
    partial class OpenStreetMapViewer
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkLabelCC = new System.Windows.Forms.LinkLabel();
            this.linkLabelOMS = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // linkLabelCC
            // 
            this.linkLabelCC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelCC.AutoSize = true;
            this.linkLabelCC.Location = new System.Drawing.Point(260, 499);
            this.linkLabelCC.Name = "linkLabelCC";
            this.linkLabelCC.Size = new System.Drawing.Size(253, 13);
            this.linkLabelCC.TabIndex = 1;
            this.linkLabelCC.TabStop = true;
            this.linkLabelCC.Text = "Creative Commons Attribution-ShareAlike 2.0 license";
            this.linkLabelCC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCC_LinkClicked);
            // 
            // linkLabelOMS
            // 
            this.linkLabelOMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelOMS.AutoSize = true;
            this.linkLabelOMS.Location = new System.Drawing.Point(289, 486);
            this.linkLabelOMS.Name = "linkLabelOMS";
            this.linkLabelOMS.Size = new System.Drawing.Size(224, 13);
            this.linkLabelOMS.TabIndex = 1;
            this.linkLabelOMS.TabStop = true;
            this.linkLabelOMS.Text = "Data is provided by OpenStreetMap under the";
            this.linkLabelOMS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOMS_LinkClicked);
            // 
            // OpenStreetMapViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.linkLabelOMS);
            this.Controls.Add(this.linkLabelCC);
            this.DoubleBuffered = true;
            this.Name = "OpenStreetMapViewer";
            this.Size = new System.Drawing.Size(512, 512);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OpenStreetMapViewer_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OpenStreetMapViewer_MouseMove);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OpenStreetMapViewer_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenStreetMapViewer_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OpenStreetMapViewer_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelCC;
        private System.Windows.Forms.LinkLabel linkLabelOMS;
    }
}
