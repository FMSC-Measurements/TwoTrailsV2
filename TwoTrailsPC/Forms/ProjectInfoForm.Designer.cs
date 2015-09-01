namespace TwoTrails.Forms
{
    partial class ProjectInfoForm
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
            this.components = new System.ComponentModel.Container();
            this.textBoxProjName = new System.Windows.Forms.TextBox();
            this.textBoxProjDescription = new System.Windows.Forms.TextBox();
            this.textBoxRegion = new System.Windows.Forms.TextBox();
            this.textBoxForest = new System.Windows.Forms.TextBox();
            this.textBoxDistrict = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkDropZeros = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkRound = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxProjName
            // 
            this.textBoxProjName.Location = new System.Drawing.Point(100, 8);
            this.textBoxProjName.Name = "textBoxProjName";
            this.textBoxProjName.Size = new System.Drawing.Size(125, 20);
            this.textBoxProjName.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxProjName, "Name of Project.");
            this.textBoxProjName.TextChanged += new System.EventHandler(this.textBoxProjName_TextChanged);
            // 
            // textBoxProjDescription
            // 
            this.textBoxProjDescription.Location = new System.Drawing.Point(100, 34);
            this.textBoxProjDescription.Name = "textBoxProjDescription";
            this.textBoxProjDescription.Size = new System.Drawing.Size(125, 20);
            this.textBoxProjDescription.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxProjDescription, "Description of Project.");
            this.textBoxProjDescription.TextChanged += new System.EventHandler(this.textBoxProjDescription_TextChanged);
            // 
            // textBoxRegion
            // 
            this.textBoxRegion.Location = new System.Drawing.Point(100, 60);
            this.textBoxRegion.Name = "textBoxRegion";
            this.textBoxRegion.Size = new System.Drawing.Size(125, 20);
            this.textBoxRegion.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxRegion, "Region of Project.");
            this.textBoxRegion.TextChanged += new System.EventHandler(this.textBoxRegion_TextChanged);
            // 
            // textBoxForest
            // 
            this.textBoxForest.Location = new System.Drawing.Point(100, 86);
            this.textBoxForest.Name = "textBoxForest";
            this.textBoxForest.Size = new System.Drawing.Size(125, 20);
            this.textBoxForest.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBoxForest, "Forest Project is Located in.");
            this.textBoxForest.TextChanged += new System.EventHandler(this.textBoxForest_TextChanged);
            // 
            // textBoxDistrict
            // 
            this.textBoxDistrict.Location = new System.Drawing.Point(100, 112);
            this.textBoxDistrict.Name = "textBoxDistrict";
            this.textBoxDistrict.Size = new System.Drawing.Size(125, 20);
            this.textBoxDistrict.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBoxDistrict, "District of Project.");
            this.textBoxDistrict.TextChanged += new System.EventHandler(this.textBoxDistrict_TextChanged);
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(100, 138);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(125, 20);
            this.textBoxYear.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textBoxYear, "Year Project was created.");
            this.textBoxYear.TextChanged += new System.EventHandler(this.textBoxYear_TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(7, 204);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(150, 204);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Region";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Forest";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "District";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(57, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Year";
            // 
            // chkDropZeros
            // 
            this.chkDropZeros.AutoSize = true;
            this.chkDropZeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDropZeros.Location = new System.Drawing.Point(100, 161);
            this.chkDropZeros.Name = "chkDropZeros";
            this.chkDropZeros.Size = new System.Drawing.Size(134, 20);
            this.chkDropZeros.TabIndex = 6;
            this.chkDropZeros.Text = "Drop Empty Pts";
            this.toolTip1.SetToolTip(this.chkDropZeros, "Checking this prevents points with a value of 0 from being created and displayed." +
                    "");
            this.chkDropZeros.UseVisualStyleBackColor = true;
            this.chkDropZeros.CheckedChanged += new System.EventHandler(this.chkDropZeros_CheckedChanged);
            // 
            // chkRound
            // 
            this.chkRound.AutoSize = true;
            this.chkRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRound.Location = new System.Drawing.Point(100, 181);
            this.chkRound.Name = "chkRound";
            this.chkRound.Size = new System.Drawing.Size(119, 20);
            this.chkRound.TabIndex = 6;
            this.chkRound.Text = "Round Points";
            this.chkRound.UseVisualStyleBackColor = true;
            this.chkRound.Visible = false;
            this.chkRound.CheckedChanged += new System.EventHandler(this.chkRound_CheckedChanged);
            // 
            // ProjectInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 234);
            this.Controls.Add(this.chkRound);
            this.Controls.Add(this.chkDropZeros);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.textBoxDistrict);
            this.Controls.Add(this.textBoxForest);
            this.Controls.Add(this.textBoxRegion);
            this.Controls.Add(this.textBoxProjDescription);
            this.Controls.Add(this.textBoxProjName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(248, 272);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(248, 272);
            this.Name = "ProjectInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Info";
            this.Load += new System.EventHandler(this.ProjectInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxProjName;
        private System.Windows.Forms.TextBox textBoxProjDescription;
        private System.Windows.Forms.TextBox textBoxRegion;
        private System.Windows.Forms.TextBox textBoxForest;
        private System.Windows.Forms.TextBox textBoxDistrict;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkDropZeros;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkRound;
    }
}