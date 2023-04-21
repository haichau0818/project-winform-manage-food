namespace PresentationLayer
{
    partial class ListItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListItem));
            this.pictureBoxImageProductSale = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUserCtrPercent = new System.Windows.Forms.Button();
            this.lblNameProductSale = new System.Windows.Forms.Label();
            this.lblPriceProductSale = new System.Windows.Forms.Label();
            this.lblAmout = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageProductSale)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxImageProductSale
            // 
            this.pictureBoxImageProductSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImageProductSale.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImageProductSale.Name = "pictureBoxImageProductSale";
            this.pictureBoxImageProductSale.Size = new System.Drawing.Size(244, 194);
            this.pictureBoxImageProductSale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImageProductSale.TabIndex = 0;
            this.pictureBoxImageProductSale.TabStop = false;
            this.pictureBoxImageProductSale.Click += new System.EventHandler(this.pictureBoxImageProductSale_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(226)))), ((int)(((byte)(225)))));
            this.panel1.Controls.Add(this.btnUserCtrPercent);
            this.panel1.Controls.Add(this.pictureBoxImageProductSale);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 194);
            this.panel1.TabIndex = 1;
            // 
            // btnUserCtrPercent
            // 
            this.btnUserCtrPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserCtrPercent.BackColor = System.Drawing.Color.Red;
            this.btnUserCtrPercent.FlatAppearance.BorderSize = 0;
            this.btnUserCtrPercent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserCtrPercent.Font = new System.Drawing.Font("Palatino Linotype", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnUserCtrPercent.ForeColor = System.Drawing.Color.White;
            this.btnUserCtrPercent.Image = ((System.Drawing.Image)(resources.GetObject("btnUserCtrPercent.Image")));
            this.btnUserCtrPercent.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUserCtrPercent.Location = new System.Drawing.Point(188, 1);
            this.btnUserCtrPercent.Name = "btnUserCtrPercent";
            this.btnUserCtrPercent.Size = new System.Drawing.Size(55, 35);
            this.btnUserCtrPercent.TabIndex = 2;
            this.btnUserCtrPercent.Text = "00";
            this.btnUserCtrPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserCtrPercent.UseVisualStyleBackColor = false;
            this.btnUserCtrPercent.Click += new System.EventHandler(this.btnUserCtrPercent_Click);
            // 
            // lblNameProductSale
            // 
            this.lblNameProductSale.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNameProductSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            this.lblNameProductSale.Location = new System.Drawing.Point(0, -2);
            this.lblNameProductSale.Name = "lblNameProductSale";
            this.lblNameProductSale.Size = new System.Drawing.Size(148, 28);
            this.lblNameProductSale.TabIndex = 4;
            this.lblNameProductSale.Text = "Tên sản phẩm ";
            this.lblNameProductSale.Click += new System.EventHandler(this.lblNameProductSale_Click);
            this.lblNameProductSale.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.lblNameProductSale.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            // 
            // lblPriceProductSale
            // 
            this.lblPriceProductSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPriceProductSale.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPriceProductSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            this.lblPriceProductSale.Location = new System.Drawing.Point(2, 29);
            this.lblPriceProductSale.Name = "lblPriceProductSale";
            this.lblPriceProductSale.Size = new System.Drawing.Size(145, 19);
            this.lblPriceProductSale.TabIndex = 5;
            this.lblPriceProductSale.Text = "Giá";
            this.lblPriceProductSale.Click += new System.EventHandler(this.lblPriceProductSale_Click);
            this.lblPriceProductSale.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.lblPriceProductSale.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            // 
            // lblAmout
            // 
            this.lblAmout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmout.AutoSize = true;
            this.lblAmout.BackColor = System.Drawing.Color.Transparent;
            this.lblAmout.Font = new System.Drawing.Font("Palatino Linotype", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblAmout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            this.lblAmout.Location = new System.Drawing.Point(224, 25);
            this.lblAmout.Name = "lblAmout";
            this.lblAmout.Size = new System.Drawing.Size(17, 17);
            this.lblAmout.TabIndex = 3;
            this.lblAmout.Text = "sl";
            this.lblAmout.Click += new System.EventHandler(this.lblAmout_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 250);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblAmout);
            this.panel2.Controls.Add(this.lblPriceProductSale);
            this.panel2.Controls.Add(this.lblNameProductSale);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 203);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 44);
            this.panel2.TabIndex = 2;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ListItem";
            this.Size = new System.Drawing.Size(250, 250);
            this.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageProductSale)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pictureBoxImageProductSale;
        public System.Windows.Forms.Button btnUserCtrPercent;
        public System.Windows.Forms.Label lblNameProductSale;
        public System.Windows.Forms.Label lblPriceProductSale;
        public System.Windows.Forms.Label lblAmout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
    }
}
