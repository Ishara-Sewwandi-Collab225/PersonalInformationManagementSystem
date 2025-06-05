namespace Personal_Information
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.centerpanel = new System.Windows.Forms.Panel();
            this.toppanel = new System.Windows.Forms.Panel();
            this.btntoppanel = new System.Windows.Forms.Panel();
            this.btntraining = new System.Windows.Forms.Button();
            this.btnexam = new System.Windows.Forms.Button();
            this.btncertificate = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnrole = new System.Windows.Forms.Button();
            this.btndepartment = new System.Windows.Forms.Button();
            this.toppanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // centerpanel
            // 
            this.centerpanel.BackColor = System.Drawing.Color.White;
            this.centerpanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("centerpanel.BackgroundImage")));
            this.centerpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.centerpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerpanel.Location = new System.Drawing.Point(0, 107);
            this.centerpanel.Name = "centerpanel";
            this.centerpanel.Size = new System.Drawing.Size(1471, 729);
            this.centerpanel.TabIndex = 5;
            this.centerpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Centerpanel_Paint);
            // 
            // toppanel
            // 
            this.toppanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toppanel.BackgroundImage")));
            this.toppanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toppanel.Controls.Add(this.btntoppanel);
            this.toppanel.Controls.Add(this.btntraining);
            this.toppanel.Controls.Add(this.btnexam);
            this.toppanel.Controls.Add(this.btncertificate);
            this.toppanel.Controls.Add(this.btnStaff);
            this.toppanel.Controls.Add(this.btnrole);
            this.toppanel.Controls.Add(this.btndepartment);
            this.toppanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toppanel.Location = new System.Drawing.Point(0, 0);
            this.toppanel.Name = "toppanel";
            this.toppanel.Size = new System.Drawing.Size(1471, 107);
            this.toppanel.TabIndex = 4;
            this.toppanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Toppanel_Paint);
            // 
            // btntoppanel
            // 
            this.btntoppanel.BackColor = System.Drawing.Color.BlueViolet;
            this.btntoppanel.Location = new System.Drawing.Point(219, 22);
            this.btntoppanel.Name = "btntoppanel";
            this.btntoppanel.Size = new System.Drawing.Size(169, 5);
            this.btntoppanel.TabIndex = 4;
            // 
            // btntraining
            // 
            this.btntraining.BackColor = System.Drawing.Color.MidnightBlue;
            this.btntraining.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntraining.ForeColor = System.Drawing.Color.White;
            this.btntraining.Location = new System.Drawing.Point(1088, 38);
            this.btntraining.Margin = new System.Windows.Forms.Padding(4);
            this.btntraining.Name = "btntraining";
            this.btntraining.Size = new System.Drawing.Size(177, 37);
            this.btntraining.TabIndex = 0;
            this.btntraining.Text = "TRAINING";
            this.btntraining.UseVisualStyleBackColor = false;
            this.btntraining.Click += new System.EventHandler(this.Btntraining_Click);
            // 
            // btnexam
            // 
            this.btnexam.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnexam.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexam.ForeColor = System.Drawing.Color.White;
            this.btnexam.Location = new System.Drawing.Point(913, 38);
            this.btnexam.Margin = new System.Windows.Forms.Padding(4);
            this.btnexam.Name = "btnexam";
            this.btnexam.Size = new System.Drawing.Size(177, 37);
            this.btnexam.TabIndex = 0;
            this.btnexam.Text = "EXAM";
            this.btnexam.UseVisualStyleBackColor = false;
            this.btnexam.Click += new System.EventHandler(this.Btnexam_Click);
            // 
            // btncertificate
            // 
            this.btncertificate.BackColor = System.Drawing.Color.MidnightBlue;
            this.btncertificate.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncertificate.ForeColor = System.Drawing.Color.White;
            this.btncertificate.Location = new System.Drawing.Point(738, 37);
            this.btncertificate.Margin = new System.Windows.Forms.Padding(4);
            this.btncertificate.Name = "btncertificate";
            this.btncertificate.Size = new System.Drawing.Size(177, 38);
            this.btncertificate.TabIndex = 0;
            this.btncertificate.Text = "CERTIFICATE";
            this.btncertificate.UseVisualStyleBackColor = false;
            this.btncertificate.Click += new System.EventHandler(this.Btncertificate_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnStaff.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.ForeColor = System.Drawing.Color.White;
            this.btnStaff.Location = new System.Drawing.Point(213, 34);
            this.btnStaff.Margin = new System.Windows.Forms.Padding(4);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(177, 41);
            this.btnStaff.TabIndex = 0;
            this.btnStaff.Text = "STAFF";
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.Click += new System.EventHandler(this.BtnStaff_Click);
            // 
            // btnrole
            // 
            this.btnrole.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnrole.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrole.ForeColor = System.Drawing.Color.White;
            this.btnrole.Location = new System.Drawing.Point(387, 34);
            this.btnrole.Margin = new System.Windows.Forms.Padding(4);
            this.btnrole.Name = "btnrole";
            this.btnrole.Size = new System.Drawing.Size(177, 41);
            this.btnrole.TabIndex = 0;
            this.btnrole.Text = "ROLE";
            this.btnrole.UseVisualStyleBackColor = false;
            this.btnrole.Click += new System.EventHandler(this.Btnposition_Click);
            // 
            // btndepartment
            // 
            this.btndepartment.BackColor = System.Drawing.Color.MidnightBlue;
            this.btndepartment.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndepartment.ForeColor = System.Drawing.Color.White;
            this.btndepartment.Location = new System.Drawing.Point(562, 35);
            this.btndepartment.Margin = new System.Windows.Forms.Padding(4);
            this.btndepartment.Name = "btndepartment";
            this.btndepartment.Size = new System.Drawing.Size(177, 39);
            this.btndepartment.TabIndex = 0;
            this.btndepartment.Text = "DEPARTMENT";
            this.btndepartment.UseVisualStyleBackColor = false;
            this.btndepartment.Click += new System.EventHandler(this.Btndepartment_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1471, 836);
            this.Controls.Add(this.centerpanel);
            this.Controls.Add(this.toppanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Home";
            this.Text = "Home";
            this.toppanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnexam;
        private System.Windows.Forms.Button btnrole;
        private System.Windows.Forms.Button btndepartment;
        private System.Windows.Forms.Button btncertificate;
        private System.Windows.Forms.Button btntraining;
        private System.Windows.Forms.Panel toppanel;
        private System.Windows.Forms.Panel centerpanel;
        private System.Windows.Forms.Panel btntoppanel;
    }
}