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
    public partial class Role : Form
    {
        public Role()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Role";
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
        private void Label1_Click(object sender, EventArgs e)
        {
            this.Close();
            //new Home().Show();
        }

        private void Role_Load(object sender, EventArgs e)
        {
            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Role";
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
             string no= txtno.Text.Trim();
             string rolename = txtname.Text.Trim();
             string description = txtdiscrip.Text.Trim();
            string salary= txtsalaryin.Text.Trim();
            string method =txtmethod.Text.Trim();
            string completed = txtcomplete.Text.Trim();
            string nic = txtnic.Text.Trim();


            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
             using (MySqlConnection connection = new MySqlConnection(connectionstring))
             {
                 try
                 {
                     connection.Open();
                     string checkQuery = "SELECT COUNT(*) FROM Role WHERE Role_No=@roleno";
                     using (MySqlCommand checkcommand = new MySqlCommand(checkQuery, connection))
                     {
                         checkcommand.Parameters.AddWithValue("@roleno", no);
                         int count = Convert.ToInt32(checkcommand.ExecuteScalar());
                         if (count > 0)
                         {
                             MessageBox.Show("Role No already exists.");
                             return;
                         }
                     }
                     string query = "INSERT INTO Role(Role_No,Role_Name,Description,Salary_Increment_Amount,Method_of_salary_increment,Complete_10_years_service,NIC_No)" + "VALUES(@roleno,@rolename,@description,@salary,@method,@completed,@nic)";

                     using (MySqlCommand command = new MySqlCommand(query, connection))
                     {
                         command.Parameters.AddWithValue("@roleno", no);
                         command.Parameters.AddWithValue("@rolename", rolename);
                         command.Parameters.AddWithValue("@description",description);
                        command.Parameters.AddWithValue("@salary", salary);
                        command.Parameters.AddWithValue("@method", method);
                        command.Parameters.AddWithValue("@completed", completed);
                        command.Parameters.AddWithValue("@nic", nic);

                        command.ExecuteNonQuery();
                         MessageBox.Show("Record inserted successfully.");
                         LoadData();

                        txtno.Clear();
                        txtname.Clear();
                         txtdiscrip.Clear();
                        txtsalaryin.Clear();
                        txtmethod.Clear();
                        txtcomplete.Clear();
                        txtnic.Clear();
                    }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Error adding record:" + ex.Message);
                 }
             }
         }

         private void Guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {

        }

        private void Guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
               txtno.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtname.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtdiscrip.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtsalaryin.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtmethod.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
               txtcomplete.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
               txtnic.Text = guna2DataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            
        }

        private void Btnupdate_Click(object sender, EventArgs e)
        {
            string no = txtno.Text.Trim();
            string rolename = txtname.Text.Trim();
            string description = txtdiscrip.Text.Trim();
            string salary = txtsalaryin.Text.Trim();
            string method = txtmethod.Text.Trim();
            string completed = txtcomplete.Text.Trim();
            string nic =txtnic.Text.Trim();

            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Role SET Role_No=@roleno,Role_Name=@rolename,Description=@description,Salary_Increment_Amount=@salry,Method_of_salary_increment=@method,Complete_10_years_service=@completed,NIC_No=@nic WHERE Role_No=@roleno";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@roleno", no);
                        command.Parameters.AddWithValue("@rolename", rolename);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@salry", salary);
                        command.Parameters.AddWithValue("@method", method);
                        command.Parameters.AddWithValue("@completed", completed);
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
        }

        private void Btndelete_Click(object sender, EventArgs e)
        {
            string no = txtno.Text.Trim();
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string depid = guna2DataGridView1.SelectedRows[0].Cells["Role_NO"].Value.ToString();
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
                    using (MySqlConnection connection = new MySqlConnection(connectionstring))
                    {
                        try
                        {
                            connection.Open();
                            string query = "DELETE FROM Role WHERE Role_No=@roleno";
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@roleno", no);
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
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Btnclear_Click(object sender, EventArgs e)
        {
            txtno.Clear();
            txtname.Clear();
           txtdiscrip.Clear();
            txtmethod.Clear();
            txtcomplete.Clear();
            txtsalaryin.Clear();
            txtnic.Clear();
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
                    string query = "SELECT Role_No, Role_Name, Description,Salary_Increment_Amount,Method_of_salary_increment,Complete_10_years_service,NIC_No FROM Role WHERE NIC_No = @nic";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nic", txtsearch.Text);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtno.Text = reader["Role_No"].ToString();
                                txtname.Text = reader["Role_Name"].ToString();
                                txtdiscrip.Text = reader["Description"].ToString();
                                txtmethod.Text = reader["Method_of_salary_increment"].ToString();
                                txtsalaryin.Text = reader["Salary_Increment_Amount"].ToString();
                                txtcomplete.Text = reader["Complete_10_years_service"].ToString();
                               txtnic.Text = reader["NIC_No"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Role not found.");
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
