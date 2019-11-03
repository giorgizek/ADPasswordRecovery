namespace ADPasswordRecovery.Win
{
    partial class Form1
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
            this.lblDomainName = new System.Windows.Forms.Label();
            this.txtDomainName = new System.Windows.Forms.TextBox();
            this.lblAdminUserName = new System.Windows.Forms.Label();
            this.txtAdminUserName = new System.Windows.Forms.TextBox();
            this.lblAdminPassword = new System.Windows.Forms.Label();
            this.txtAdminPassword = new System.Windows.Forms.TextBox();
            this.btnGetUsers = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.lblManageableRoles = new System.Windows.Forms.Label();
            this.txtManageableRoles = new System.Windows.Forms.TextBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDomainName
            // 
            this.lblDomainName.AutoSize = true;
            this.lblDomainName.Location = new System.Drawing.Point(10, 15);
            this.lblDomainName.Name = "lblDomainName";
            this.lblDomainName.Size = new System.Drawing.Size(77, 13);
            this.lblDomainName.TabIndex = 0;
            this.lblDomainName.Text = "Domain Name:";
            // 
            // txtDomainName
            // 
            this.txtDomainName.Location = new System.Drawing.Point(111, 12);
            this.txtDomainName.Name = "txtDomainName";
            this.txtDomainName.Size = new System.Drawing.Size(206, 20);
            this.txtDomainName.TabIndex = 1;
            this.txtDomainName.Text = "192.168.201.2";
            // 
            // lblAdminUserName
            // 
            this.lblAdminUserName.AutoSize = true;
            this.lblAdminUserName.Location = new System.Drawing.Point(10, 41);
            this.lblAdminUserName.Name = "lblAdminUserName";
            this.lblAdminUserName.Size = new System.Drawing.Size(95, 13);
            this.lblAdminUserName.TabIndex = 0;
            this.lblAdminUserName.Text = "Admin User Name:";
            // 
            // txtAdminUserName
            // 
            this.txtAdminUserName.Location = new System.Drawing.Point(111, 38);
            this.txtAdminUserName.Name = "txtAdminUserName";
            this.txtAdminUserName.Size = new System.Drawing.Size(206, 20);
            this.txtAdminUserName.TabIndex = 1;
            this.txtAdminUserName.Text = "agirich";
            // 
            // lblAdminPassword
            // 
            this.lblAdminPassword.AutoSize = true;
            this.lblAdminPassword.Location = new System.Drawing.Point(10, 67);
            this.lblAdminPassword.Name = "lblAdminPassword";
            this.lblAdminPassword.Size = new System.Drawing.Size(88, 13);
            this.lblAdminPassword.TabIndex = 0;
            this.lblAdminPassword.Text = "Admin Password:";
            // 
            // txtAdminPassword
            // 
            this.txtAdminPassword.Location = new System.Drawing.Point(111, 64);
            this.txtAdminPassword.Name = "txtAdminPassword";
            this.txtAdminPassword.Size = new System.Drawing.Size(206, 20);
            this.txtAdminPassword.TabIndex = 1;
            this.txtAdminPassword.Text = "edcedc4$";
            // 
            // btnGetUsers
            // 
            this.btnGetUsers.Location = new System.Drawing.Point(323, 87);
            this.btnGetUsers.Name = "btnGetUsers";
            this.btnGetUsers.Size = new System.Drawing.Size(75, 23);
            this.btnGetUsers.TabIndex = 2;
            this.btnGetUsers.Text = "Get";
            this.btnGetUsers.UseVisualStyleBackColor = true;
            this.btnGetUsers.Click += new System.EventHandler(this.btnGetUsers_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 122);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.Size = new System.Drawing.Size(611, 287);
            this.dgvUsers.TabIndex = 3;
            // 
            // lblManageableRoles
            // 
            this.lblManageableRoles.AutoSize = true;
            this.lblManageableRoles.Location = new System.Drawing.Point(10, 93);
            this.lblManageableRoles.Name = "lblManageableRoles";
            this.lblManageableRoles.Size = new System.Drawing.Size(99, 13);
            this.lblManageableRoles.TabIndex = 0;
            this.lblManageableRoles.Text = "Manageable Roles:";
            // 
            // txtManageableRoles
            // 
            this.txtManageableRoles.Location = new System.Drawing.Point(111, 90);
            this.txtManageableRoles.Name = "txtManageableRoles";
            this.txtManageableRoles.Size = new System.Drawing.Size(206, 20);
            this.txtManageableRoles.TabIndex = 1;
            this.txtManageableRoles.Text = "Domain Users";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblDomainName);
            this.pnlTop.Controls.Add(this.txtDomainName);
            this.pnlTop.Controls.Add(this.btnGetUsers);
            this.pnlTop.Controls.Add(this.lblAdminUserName);
            this.pnlTop.Controls.Add(this.txtManageableRoles);
            this.pnlTop.Controls.Add(this.txtAdminUserName);
            this.pnlTop.Controls.Add(this.lblManageableRoles);
            this.pnlTop.Controls.Add(this.lblAdminPassword);
            this.pnlTop.Controls.Add(this.txtAdminPassword);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(611, 122);
            this.pnlTop.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 409);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.pnlTop);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDomainName;
        private System.Windows.Forms.TextBox txtDomainName;
        private System.Windows.Forms.Label lblAdminUserName;
        private System.Windows.Forms.TextBox txtAdminUserName;
        private System.Windows.Forms.Label lblAdminPassword;
        private System.Windows.Forms.TextBox txtAdminPassword;
        private System.Windows.Forms.Button btnGetUsers;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label lblManageableRoles;
        private System.Windows.Forms.TextBox txtManageableRoles;
        private System.Windows.Forms.Panel pnlTop;
    }
}

