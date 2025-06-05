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
    public partial class Training : Form
    {
        public Training()
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
                    string query = "SELECT * FROM Training";
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
           // this.Close();
            //new Home().Show();
        }

        private void Training_Load(object sender, EventArgs e)
        {

           string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Training";
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
            string Traineeno = txtno.Text.Trim();
            string Traineename = txtname.Text.Trim();
            DateTime Startdate = DateTime.Now;
            DateTime Enddate = DateTime.Now;
            string nic =txtnic.Text.Trim();


            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Training WHERE Trainee_No=@Traineeno";
                    using (MySqlCommand checkcommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkcommand.Parameters.AddWithValue("@Traineeno", Traineeno);
                        int count = Convert.ToInt32(checkcommand.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Role No already exists.");
                            return;
                        }
                    }
                    string query = "INSERT INTO Training(Trainee_No,Name,Start_Date,End_Date,NIC_No)" + "VALUES(@Traineeno,@Traineename,@Startdate,@Enddate,@nic)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Traineeno", Traineeno);
                        command.Parameters.AddWithValue("@Traineename", Traineename);
                        command.Parameters.AddWithValue("@Startdate", Startdate);
                        command.Parameters.AddWithValue("@Enddate", Enddate);
                        command.Parameters.AddWithValue("@nic", nic);


                        command.ExecuteNonQuery();
                        MessageBox.Show("Record inserted successfully.");
                        LoadData();

                        txtno.Clear();
                        txtname.Clear();
                        txtsdate.Text = Startdate.ToString("yyyy-MM-dd HH:mm:ss");
                       txtedate.Text = Enddate.ToString("yyyy-MM-dd HH:mm:ss");
                       txtnic.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding record:" + ex.Message);
                }
            }
        }

        private void Btnupdate_Click(object sender, EventArgs e)
        {
            string Traineeno = txtno.Text.Trim();
            string Traineename = txtname.Text.Trim();
            DateTime Startdate = DateTime.Now;
            DateTime Enddate = DateTime.Now;
            string nic = txtnic.Text.Trim();

            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Training SET Trainee_No=@Traineeno,Name=@Traineename,Start_Date=@Startdate,End_Date=@Enddate,Nic_No=@nic WHERE Trainee_No=@Traineeno";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Traineeno", Traineeno);
                        command.Parameters.AddWithValue("@Traineename", Traineename);
                        command.Parameters.AddWithValue("@Startdate", Startdate);
                        command.Parameters.AddWithValue("@Enddate", Enddate);
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
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                string Traineeno = guna2DataGridView1.SelectedRows[0].Cells["Trainee_NO"].Value.ToString();
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
                    using (MySqlConnection connection = new MySqlConnection(connectionstring))
                    {
                        try
                        {
                            connection.Open();
                            string query = "DELETE FROM Training WHERE Trainee_No=@Traineeno";
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Traineeno", Traineeno);
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

        private void Btnclear_Click(object sender, EventArgs e)
        {
            txtno.Clear();
            txtname.Clear();
            txtsdate.Clear();
            txtedate.Clear();
            txtnic.Clear();

        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
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
                    string query = "SELECT Trainee_No,Name, Start_Date,End_Date,NIC_No FROM Training WHERE NIC_No = @nic";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nic", txtsearch.Text);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtno.Text = reader["Trainee_No"].ToString();
                                txtname.Text = reader["Name"].ToString();
                                txtsdate.Text = reader["Start_Date"].ToString();
                                txtedate.Text = reader["End_Date"].ToString();
                                 txtnic.Text = reader["NIC_No"].ToString();

                            }
                            else
                            {
                                MessageBox.Show("Training not found.");
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

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtsdate.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd hh:MM:ss");
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtedate.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd hh:MM:ss");
        }
    }
}

        
