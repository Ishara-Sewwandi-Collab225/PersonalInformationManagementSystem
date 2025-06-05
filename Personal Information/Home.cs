using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_Information
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.Bounds.Size;

            this.Location = new Point(0, 0);
        }
        private void LoadForm(Form form)
        {
            centerpanel.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            centerpanel.Controls.Add(form);
            form.Show();


        }
        private void MovePanel(Control btn)
        {
            btntoppanel.Left = btn.Left;
            btntoppanel.Width = btn.Width;
        }

        private void BtnStaff_Click(object sender, EventArgs e)
        {
            MovePanel(btnStaff);
            LoadForm(new Staff());
        }

        private void Btnposition_Click(object sender, EventArgs e)
        {
            MovePanel(btnrole);
            LoadForm(new Role());
        }

        private void Btndepartment_Click(object sender, EventArgs e)
        {
            MovePanel(btndepartment);
            LoadForm(new Department());
        }

        private void Btncertificate_Click(object sender, EventArgs e)
        {
            MovePanel(btncertificate);
            LoadForm(new Certificate());
        }

        private void Btnexam_Click(object sender, EventArgs e)
        {
            MovePanel(btnexam);
            LoadForm(new Exam());
        }

        private void Btntraining_Click(object sender, EventArgs e)
        {
            MovePanel(btntraining);
            LoadForm(new Training());
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Lblcategory_Click(object sender, EventArgs e)
        {

        }

        private void Centerpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Toppanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btnsearch_Click(object sender, EventArgs e)
        {
            
        }
    }
}
