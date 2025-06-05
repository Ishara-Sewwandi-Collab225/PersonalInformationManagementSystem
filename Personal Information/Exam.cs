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
    public partial class Exam : Form
    {
        public Exam()
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
                    string query = "SELECT * FROM Exam";
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
            
           
        }

        private void Btnadd_Click(object sender, EventArgs e)
        {
            string no = txtno.Text.Trim();
            string name = txtname.Text.Trim();
            string result= txtresult.Text.Trim();
            string nic = txtnic.Text.Trim();




            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Exam WHERE Exam_No=@no";
                    using (MySqlCommand checkcommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkcommand.Parameters.AddWithValue("@no", no);
                        int count = Convert.ToInt32(checkcommand.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Exam No already exists.");
                            return;
                        }
                    }
                    string query = "INSERT INTO Exam(Exam_NO,Exam_Name,Result_of_exam,NIC_No)" + "VALUES(@no,@name,@result,@nic)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@no", no);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@result", result);
                        command.Parameters.AddWithValue("@nic", nic);



                        command.ExecuteNonQuery();
                        MessageBox.Show("Record inserted successfully.");
                        LoadData();

                        txtno.Clear();
                        txtname.Clear();
                        txtresult.Clear();
                        txtnic.Clear();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding record:" + ex.Message);
                }
            }
        }

        private void Exam_Load(object sender, EventArgs e)
        {
            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Exam";
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

        private void Btnupdate_Click(object sender, EventArgs e)
        {
            string no = txtno.Text.Trim();
            string name = txtname.Text.Trim();
            string result = txtresult.Text.Trim();
            string nic = txtnic.Text.Trim();



            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Exam SET Exam_No=@no,Exam_Name=@name,Result_of_exam=@result,NIC_No=@nic WHERE Exam_No=@no";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@no", no);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@result", result);
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
                string no = guna2DataGridView1.SelectedRows[0].Cells["Exam_NO"].Value.ToString();
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
                    using (MySqlConnection connection = new MySqlConnection(connectionstring))
                    {
                        try
                        {
                            connection.Open();
                            string query = "DELETE FROM Exam WHERE Exam_No=@no";
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@no",no);
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
           txtresult.Clear();
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
                    string query = "SELECT Exam_No,Exam_Name, Result_of_exam,NIC_No FROM Exam WHERE NIC_No = @nic";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nic", txtsearch.Text);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtno.Text = reader["Exam_No"].ToString();
                                txtname.Text = reader["Exam_Name"].ToString();
                               txtresult.Text = reader["Result_of_exam"].ToString();
                                txtnic.Text = reader["NIC_No"].ToString();


                            }
                            else
                            {
                                MessageBox.Show("Exam not found.");
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
