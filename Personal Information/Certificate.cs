using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Personal_Information
{
    public partial class Certificate : Form
    {
        public Certificate()
        {
            InitializeComponent();


            this.Load += Certificate_Load;
            pictureBox1.Click += PictureBox1_Click;
            pictureBox2.Click += PictureBox2_Click;
            pictureBox3.Click += PictureBox3_Click;

            guna2DataGridView1.CellClick += Guna2DataGridView1_CellClick;


        }

        private void Certificate_Load(object sender, EventArgs e)
        {
            LoadCertificatesToGrid();
        }

        // -------------------- Browse Image Buttons --------------------

        private void Btnbrows_Click(object sender, EventArgs e)
        {
            BrowseImage(pictureBox1, "Select Birth Certificate");
        }

        private void Btnbrows1_Click(object sender, EventArgs e)
        {
            BrowseImage(pictureBox2, "Select Commission Letter");
        }

        private void Btnbrows2_Click(object sender, EventArgs e)
        {
            BrowseImage(pictureBox3, "Select Appointment Letter");
        }

        private void BrowseImage(PictureBox pictureBox, string title)
        {
            openFileDialog1.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            openFileDialog1.Title = title;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        // -------------------- Save All Images --------------------

        private void BtnSaveAll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcertino.Text))
            {
                MessageBox.Show("Please enter certificate number.");
                return;
            }

            byte[] birth = ImageToBytes(pictureBox1.Image);
            byte[] commission = ImageToBytes(pictureBox2.Image);
            byte[] appointment = ImageToBytes(pictureBox3.Image);

            string connStr = "server=localhost;user=root;database=Personalinfo;password=1234";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"
                        REPLACE INTO Certificate 
                        (Certificate_No, Birth_Certificate, Commision_letter, Appoinment_letter, NIC_No) 
                        VALUES (@no, @birth, @commission, @appointment, @nic)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@no", txtcertino.Text);
                    cmd.Parameters.AddWithValue("@birth", birth);
                    cmd.Parameters.AddWithValue("@commission", commission);
                    cmd.Parameters.AddWithValue("@appointment", appointment);
                    cmd.Parameters.AddWithValue("@nic", txtnic.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Certificate saved successfully.");
                LoadCertificatesToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving certificate: " + ex.Message);
            }
        }

        // -------------------- Load Images by Certificate Number --------------------

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCertNo.Text))
            {
                MessageBox.Show("Please enter NIC number to search.");
                return;
            }

            string connectionString = "server=localhost;user=root;database=Personalinfo;password=1234";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Birth_Certificate, Commision_letter, Appoinment_letter, NIC_No, Certificate_No FROM Certificate WHERE NIC_No = @nic";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nic", txtSearchCertNo.Text);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                byte[] birthBytes = reader["Birth_Certificate"] as byte[];
                                byte[] commissionBytes = reader["Commision_letter"] as byte[];
                                byte[] appointmentBytes = reader["Appoinment_letter"] as byte[];

                                pictureBox1.Image = birthBytes != null ? ByteArrayToImage(birthBytes) : null;
                                pictureBox2.Image = commissionBytes != null ? ByteArrayToImage(commissionBytes) : null;
                                pictureBox3.Image = appointmentBytes != null ? ByteArrayToImage(appointmentBytes) : null;

                                txtcertino.Text = reader["Certificate_No"].ToString();
                                txtnic.Text = reader["NIC_No"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Certificate not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading certificate: " + ex.Message);
            }
        }

        // -------------------- Load Data to DataGridView --------------------

        private void LoadCertificatesToGrid()
        {
            string connStr = "server=localhost;user=root;database=Personalinfo;password=1234";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT Certificate_No, NIC_No FROM Certificate";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    guna2DataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // -------------------- Handle Row Click to Load Images --------------------

        private void Guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                string certNo = row.Cells["Certificate_No"].Value.ToString();
                txtSearchCertNo.Text = certNo;
                BtnLoad_Click(sender, e); // Reuse the load button logic
            }
        }

        // -------------------- Update Certificate --------------------

        private void Btnupdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcertino.Text))
            {
                MessageBox.Show("Please enter certificate number to update.");
                return;
            }

            byte[] birth = ImageToBytes(pictureBox1.Image);
            byte[] commission = ImageToBytes(pictureBox2.Image);
            byte[] appointment = ImageToBytes(pictureBox3.Image);

            string connStr = "server=localhost;user=root;database=Personalinfo;password=1234";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"
                        UPDATE Certificate SET 
                            Birth_Certificate = @birth,
                            Commision_letter = @commission,
                            Appoinment_letter = @appointment,
                            NIC_No = @nic
                        WHERE Certificate_No = @no";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@no", txtcertino.Text);
                    cmd.Parameters.AddWithValue("@birth", birth);
                    cmd.Parameters.AddWithValue("@commission", commission);
                    cmd.Parameters.AddWithValue("@appointment", appointment);
                    cmd.Parameters.AddWithValue("@nic", txtnic.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Certificate updated successfully.");
                    else
                        MessageBox.Show("Certificate number not found.");

                    LoadCertificatesToGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating certificate: " + ex.Message);
            }
        }

        // -------------------- Delete Certificate --------------------

        private void Btndelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCertNo.Text))
            {
                MessageBox.Show("Please enter certificate number to delete.");
                return;
            }

            string connStr = "server=localhost;user=root;database=Personalinfo;password=1234";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "DELETE FROM Certificate WHERE Certificate_No = @no";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@no", txtSearchCertNo.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        pictureBox1.Image = null;
                        pictureBox2.Image = null;
                        pictureBox3.Image = null;
                        txtcertino.Clear();
                        txtSearchCertNo.Clear();
                        txtnic.Clear();

                        MessageBox.Show("Certificate deleted successfully.");
                        LoadCertificatesToGrid();
                    }
                    else
                    {
                        MessageBox.Show("Certificate not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting certificate: " + ex.Message);
            }
        }

        // -------------------- Clear Fields --------------------

        private void Btnclear_Click(object sender, EventArgs e)
        {
            txtcertino.Clear();
            txtSearchCertNo.Clear();
            txtnic.Clear();
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
        }

        // -------------------- Exit --------------------

        private void Btnexit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // -------------------- Helper Methods --------------------

        private byte[] ImageToBytes(Image img)
        {
            if (img == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            if (clickedPictureBox != null && clickedPictureBox.Image != null)
            {
                ImageViewerForm viewer = new ImageViewerForm(clickedPictureBox.Image);
                viewer.ShowDialog();
            }


        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            if (clickedPictureBox != null && clickedPictureBox.Image != null)
            {
                ImageViewerForm viewer = new ImageViewerForm(clickedPictureBox.Image);
                viewer.ShowDialog();
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            if (clickedPictureBox != null && clickedPictureBox.Image != null)
            {
                ImageViewerForm viewer = new ImageViewerForm(clickedPictureBox.Image);
                viewer.ShowDialog();
            }
        }
    }
}
