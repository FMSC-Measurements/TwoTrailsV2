namespace TwoTrails.Forms
{
    partial class MassEditForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstPoints = new System.Windows.Forms.ListView();
            this.btnSwitchPoly = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnPolygon = new System.Windows.Forms.Button();
            this.cboPoly = new System.Windows.Forms.ComboBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnBnd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(3, 266);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 25);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Tag = "Exit Form";
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(167, 266);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Tag = "Save and Exit";
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lstPoints
            // 
            this.lstPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPoints.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lstPoints.Location = new System.Drawing.Point(0, 34);
            this.lstPoints.Name = "lstPoints";
            this.lstPoints.Size = new System.Drawing.Size(240, 195);
            this.lstPoints.TabIndex = 1;
            this.lstPoints.TabStop = false;
            this.lstPoints.View = System.Windows.Forms.View.Details;
            // 
            // btnSwitchPoly
            // 
            this.btnSwitchPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSwitchPoly.Location = new System.Drawing.Point(3, 235);
            this.btnSwitchPoly.Name = "btnSwitchPoly";
            this.btnSwitchPoly.Size = new System.Drawing.Size(108, 25);
            this.btnSwitchPoly.TabIndex = 0;
            this.btnSwitchPoly.TabStop = false;
            this.btnSwitchPoly.Tag = "Switch Points to a different Polygon";
            this.btnSwitchPoly.Text = "Switch Polygon";
            this.btnSwitchPoly.Click += new System.EventHandler(this.btnSwitchPoly_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Location = new System.Drawing.Point(117, 235);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(120, 25);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.TabStop = false;
            this.btnConvert.Tag = "Convert Quondams to the type and value of their parrent point.";
            this.btnConvert.Text = "Convert Quondam";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnPolygon
            // 
            this.btnPolygon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPolygon.Location = new System.Drawing.Point(144, 3);
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(93, 25);
            this.btnPolygon.TabIndex = 0;
            this.btnPolygon.TabStop = false;
            this.btnPolygon.Text = "Polygon";
            this.btnPolygon.Click += new System.EventHandler(this.btnPolygon_Click);
            // 
            // cboPoly
            // 
            this.cboPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPoly.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cboPoly.Location = new System.Drawing.Point(144, 3);
            this.cboPoly.Name = "cboPoly";
            this.cboPoly.Size = new System.Drawing.Size(92, 22);
            this.cboPoly.TabIndex = 2;
            this.cboPoly.TabStop = false;
            this.cboPoly.SelectedIndexChanged += new System.EventHandler(this.cboPoly_SelectedIndexChanged);
            // 
            // chkAll
            // 
            this.chkAll.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkAll.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkAll.Location = new System.Drawing.Point(3, 15);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(100, 20);
            this.chkAll.TabIndex = 3;
            this.chkAll.TabStop = false;
            this.chkAll.Text = "Select All";
            this.chkAll.CheckStateChanged += new System.EventHandler(this.chkAll_CheckStateChanged);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(80, 266);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(81, 25);
            this.btnDel.TabIndex = 4;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnBnd
            // 
            this.btnBnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBnd.Location = new System.Drawing.Point(101, 3);
            this.btnBnd.Name = "btnBnd";
            this.btnBnd.Size = new System.Drawing.Size(37, 25);
            this.btnBnd.TabIndex = 4;
            this.btnBnd.TabStop = false;
            this.btnBnd.Text = "On";
            this.btnBnd.Click += new System.EventHandler(this.btnBnd_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(25, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.Text = "Boundary:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MassEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.btnBnd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lstPoints);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnPolygon);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSwitchPoly);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cboPoly);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.label1);
            this.Name = "MassEditForm";
            this.Text = "Mass Point Edit";
            this.ResumeLayout(false);

        }

        private void InitializeComponentWide()
        {
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstPoints = new System.Windows.Forms.ListView();
            this.btnSwitchPoly = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnPolygon = new System.Windows.Forms.Button();
            this.cboPoly = new System.Windows.Forms.ComboBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnBnd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(247, 181);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(68, 25);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Tag = "Exit Form";
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(247, 119);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Tag = "Save and Exit";
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lstPoints
            // 
            this.lstPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPoints.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lstPoints.Location = new System.Drawing.Point(0, 33);
            this.lstPoints.Name = "lstPoints";
            this.lstPoints.Size = new System.Drawing.Size(241, 180);
            this.lstPoints.TabIndex = 1;
            this.lstPoints.TabStop = false;
            this.lstPoints.View = System.Windows.Forms.View.Details;
            // 
            // btnSwitchPoly
            // 
            this.btnSwitchPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSwitchPoly.Location = new System.Drawing.Point(247, 57);
            this.btnSwitchPoly.Name = "btnSwitchPoly";
            this.btnSwitchPoly.Size = new System.Drawing.Size(68, 44);
            this.btnSwitchPoly.TabIndex = 0;
            this.btnSwitchPoly.TabStop = false;
            this.btnSwitchPoly.Tag = "Switch Points to a different Polygon";
            this.btnSwitchPoly.Text = "Switch Polygon";
            this.btnSwitchPoly.Click += new System.EventHandler(this.btnSwitchPoly_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Location = new System.Drawing.Point(247, 3);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(68, 48);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.TabStop = false;
            this.btnConvert.Tag = "Convert Quondams to the type and value of their parrent point.";
            this.btnConvert.Text = "Convert Quondam";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnPolygon
            // 
            this.btnPolygon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPolygon.Location = new System.Drawing.Point(224, -77);
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(93, 25);
            this.btnPolygon.TabIndex = 0;
            this.btnPolygon.TabStop = false;
            this.btnPolygon.Text = "Polygon";
            this.btnPolygon.Click += new System.EventHandler(this.btnPolygon_Click);
            // 
            // cboPoly
            // 
            this.cboPoly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPoly.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cboPoly.Location = new System.Drawing.Point(166, 6);
            this.cboPoly.Name = "cboPoly";
            this.cboPoly.Size = new System.Drawing.Size(75, 22);
            this.cboPoly.TabIndex = 2;
            this.cboPoly.TabStop = false;
            this.cboPoly.SelectedIndexChanged += new System.EventHandler(this.cboPoly_SelectedIndexChanged);
            // 
            // chkAll
            // 
            this.chkAll.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkAll.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.chkAll.Location = new System.Drawing.Point(3, 8);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(87, 20);
            this.chkAll.TabIndex = 3;
            this.chkAll.TabStop = false;
            this.chkAll.Text = "Select All";
            this.chkAll.CheckStateChanged += new System.EventHandler(this.chkAll_CheckStateChanged);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(247, 150);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(68, 25);
            this.btnDel.TabIndex = 4;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnBnd
            // 
            this.btnBnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBnd.Location = new System.Drawing.Point(166, 6);
            this.btnBnd.Name = "btnBnd";
            this.btnBnd.Size = new System.Drawing.Size(75, 22);
            this.btnBnd.TabIndex = 4;
            this.btnBnd.TabStop = false;
            this.btnBnd.Text = "On";
            this.btnBnd.Click += new System.EventHandler(this.btnBnd_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(85, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.Text = "Boundary:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.lstPoints);
            this.panel1.Controls.Add(this.btnConvert);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.btnSwitchPoly);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 214);
            // 
            // MassEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.Controls.Add(this.btnBnd);
            this.Controls.Add(this.btnPolygon);
            this.Controls.Add(this.cboPoly);
            this.Controls.Add(this.panel1);
            this.Name = "MassEditForm";
            this.Text = "Mass Point Edit";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lstPoints;
        private System.Windows.Forms.Button btnSwitchPoly;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnPolygon;
        private System.Windows.Forms.ComboBox cboPoly;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnBnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}