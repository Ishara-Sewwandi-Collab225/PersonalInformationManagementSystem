using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Personal_Information
{
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
            LoadData();
        }

        private void Lbldepname_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Department";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    guna2DataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data:" + ex.Message);
                }
            }
        }

        private void Btnhome_Click(object sender, EventArgs e)
        {

        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.Close();
            //new Home().Show();
        }

        private void Department_Load(object sender, EventArgs e)
        {
            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Department";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    guna2DataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data:" + ex.Message);
                }
            }
        }

        private void Btnadd_Click(object sender, EventArgs e)
        {
            string depid = txtdepid.Text.Trim();
            string name = txtname.Text.Trim();
            string location = txtlocation.Text.Trim();
            string nic = txtnic.Text.Trim();

            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Department WHERE Department_ID=@depid";
                    using (MySqlCommand checkcommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkcommand.Parameters.AddWithValue("@depid", depid);
                        int count = Convert.ToInt32(checkcommand.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Department ID already exists.");
                            return;
                        }
                    }
                    string query = "INSERT INTO Department(Department_ID,Department_Name,Location,NIC_No)" + "VALUES(@depid,@name,@location,@nic)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@depid", depid);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@location", location);
                        command.Parameters.AddWithValue("@nic", nic);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Record inserted successfully.");
                        LoadData();

                        txtdepid.Clear();
                        txtname.Clear();
                        txtlocation.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding record:" + ex.Message);
                }
            }
            LoadData();
        }

        private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtdepid.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtname.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtlocation.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtnic.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void Btnupdate_Click(object sender, EventArgs e)
        {
            string depid = txtdepid.Text.Trim();
            string name = txtname.Text.Trim();
            string location = txtlocation.Text.Trim();
            string nic = txtnic.Text.Trim();

            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Department SET Department_ID=@depid,Department_Name=@name,Location=@location,NIC_No=@nic WHERE Department_ID=@depid";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@depid", depid);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@location", location);
                        command.Parameters.AddWithValue("@nic", nic);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record update successfully.");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("No matching record found to update.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while updating:" + ex.Message);
                }
            }
            LoadData();
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string depid = guna2DataGridView1.SelectedRows[0].Cells["Department_ID"].Value.ToString();
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
                    using (MySqlConnection connection = new MySqlConnection(connectionstring))
                    {
                        try
                        {
                            connection.Open();
                            string query = "DELETE FROM Department WHERE Department_ID=@depid";
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@depid", depid);
                                command.ExecuteNonQuery();
                            }
                            MessageBox.Show("Record deleted successfully.");
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting record:" + ex.Message);
                        }
                    }
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            txtdepid.Clear();
            txtname.Clear();
            txtlocation.Clear();
           txtnic.Clear();

        }

        private void Btnview_Click(object sender, EventArgs e)
        {

        }

        private void Btnsearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtsearch.Text))
            {
                MessageBox.Show("Please enter nic no to search.");
                return;
            }

            string connectionString = "server=localhost;user=root;database=Personalinfo;password=1234";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Department_ID, Department_Name, Location,NIC_No FROM Department WHERE NIC_No = @nic";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nic", txtsearch.Text);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtdepid.Text = reader["Department_ID"].ToString();
                                txtname.Text = reader["Department_Name"].ToString();
                                txtlocation.Text = reader["Location"].ToString();
                                txtnic.Text = reader["NIC_No"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Department not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching: " + ex.Message);
            }
        }
    }
}
            
