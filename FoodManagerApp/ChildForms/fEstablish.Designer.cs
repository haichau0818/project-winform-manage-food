namespace PresentationLayer
{
    partial class fEstablish
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
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPasswordNew = new System.Windows.Forms.TextBox();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNameUser = new System.Windows.Forms.TextBox();
            this.btnLoginChange = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChangePassword.BackColor = System.Drawing.Color.Crimson;
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(20, 141);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(249, 45);
            this.btnChangePassword.TabIndex = 6;
            this.btnChangePassword.Text = "Xác nhận";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(465, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐỔI MẬT KHẨU";
            // 
            // txtPasswordNew
            // 
            this.txtPasswordNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPasswordNew.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPasswordNew.ForeColor = System.Drawing.Color.DimGray;
            this.txtPasswordNew.Location = new System.Drawing.Point(20, 18);
            this.txtPasswordNew.Multiline = true;
            this.txtPasswordNew.Name = "txtPasswordNew";
            this.txtPasswordNew.Size = new System.Drawing.Size(249, 36);
            this.txtPasswordNew.TabIndex = 4;
            this.txtPasswordNew.Text = "Mật khẩu mới";
            this.txtPasswordNew.Click += new System.EventHandler(this.txtPasswordNew_Click);
            this.txtPasswordNew.TextChanged += new System.EventHandler(this.txtPasswordNew_TextChanged);
            this.txtPasswordNew.Leave += new System.EventHandler(this.txtPasswordNew_Leave);
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConfirmPass.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtConfirmPass.ForeColor = System.Drawing.Color.DimGray;
            this.txtConfirmPass.Location = new System.Drawing.Point(20, 81);
            this.txtConfirmPass.Multiline = true;
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(249, 36);
            this.txtConfirmPass.TabIndex = 5;
            this.txtConfirmPass.Text = "Xác nhận mật khẩu";
            this.txtConfirmPass.Click += new System.EventHandler(this.txtConfirmPass_Click);
            this.txtConfirmPass.TextChanged += new System.EventHandler(this.txtConfirmPass_TextChanged);
            this.txtConfirmPass.Leave += new System.EventHandler(this.txtConfirmPass_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtConfirmPass);
            this.panel1.Controls.Add(this.btnChangePassword);
            this.panel1.Controls.Add(this.txtPasswordNew);
            this.panel1.Location = new System.Drawing.Point(453, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 225);
            this.panel1.TabIndex = 8;
            this.panel1.Visible = false;
            // 
            // txtNameUser
            // 
            this.txtNameUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNameUser.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtNameUser.ForeColor = System.Drawing.Color.DimGray;
            this.txtNameUser.Location = new System.Drawing.Point(473, 157);
            this.txtNameUser.Multiline = true;
            this.txtNameUser.Name = "txtNameUser";
            this.txtNameUser.Size = new System.Drawing.Size(249, 36);
            this.txtNameUser.TabIndex = 1;
            this.txtNameUser.Text = "Tên tài khoản";
            this.txtNameUser.Click += new System.EventHandler(this.txtNameUser_Click);
            this.txtNameUser.Leave += new System.EventHandler(this.txtNameUser_Leave);
            // 
            // btnLoginChange
            // 
            this.btnLoginChange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoginChange.BackColor = System.Drawing.Color.Crimson;
            this.btnLoginChange.FlatAppearance.BorderSize = 0;
            this.btnLoginChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginChange.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLoginChange.ForeColor = System.Drawing.Color.White;
            this.btnLoginChange.Location = new System.Drawing.Point(473, 274);
            this.btnLoginChange.Name = "btnLoginChange";
            this.btnLoginChange.Size = new System.Drawing.Size(249, 45);
            this.btnLoginChange.TabIndex = 3;
            this.btnLoginChange.Text = "Đổi mật khẩu";
            this.btnLoginChange.UseVisualStyleBackColor = false;
            this.btnLoginChange.Click += new System.EventHandler(this.btnLoginChange_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPassword.ForeColor = System.Drawing.Color.DimGray;
            this.txtPassword.Location = new System.Drawing.Point(473, 213);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(249, 36);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Nhập mật khẩu";
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click_1);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave_1);
            // 
            // fEstablish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 630);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLoginChange);
            this.Controls.Add(this.txtNameUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fEstablish";
            this.Text = "THIẾT LẬP";
            this.Load += new System.EventHandler(this.fEstablish_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPasswordNew;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNameUser;
        private System.Windows.Forms.Button btnLoginChange;
        private System.Windows.Forms.TextBox txtPassword;
    }
}