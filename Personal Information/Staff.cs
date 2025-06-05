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
    public partial class Staff : Form
    {
        public Staff()
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
                    string query = "SELECT * FROM Staff";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    guna2DataGridView2.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data:" + ex.Message);
                }
            }
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Staff";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    guna2DataGridView2.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {

        }

        private void Btnhome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void Staff_Load_1(object sender, EventArgs e)
        {
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            this.Close();
            // new Home().Show();
        }

        private void Btnaddd_Click(object sender, EventArgs e)
        {
            string nic = txtnicno.Text.Trim();
            string name = txtemname.Text.Trim();
            DateTime birth = DateTime.Now;

            string age = txtages.Text.Trim();
            string phone = txtphone.Text.Trim();
            string gender = txtgen.Text.Trim();
            string email = txtmail.Text.Trim();
            if (!decimal.TryParse(txtsal.Text.Trim(), out decimal salary))
            {
                MessageBox.Show("Invalid salary");
                return;
            }

            string edQualification = txteduquali.Text.Trim();
            string highqualification = txthquali.Text.Trim();
            DateTime join = DateTime.Now;
            DateTime endpro = DateTime.Now;
            string confirmation = txtconfirm.Text.Trim();

            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Staff WHERE NIC_No=@nic";
                    using (MySqlCommand checkcommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkcommand.Parameters.AddWithValue("@nic", nic);
                        int count = Convert.ToInt32(checkcommand.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("NIC Number already exists.");
                            return;
                        }
                    }

                    string query = "INSERT INTO Staff(NIC_No, Name, Date_of_birth, Age, Gender, Email, Telephone, Salary, Education_qualification, Higher_Qualification,Date_of_joining, End_of_the_probationary, Confirmation_status) " +
                                   "VALUES(@nic, @name, @birth, @age, @gender, @email, @phone, @salary, @edQualification, @highqualification, @join, @endpro, @confirmation)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nic", nic);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@birth", birth);
                        command.Parameters.AddWithValue("@age", age);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@salary", salary);
                        command.Parameters.AddWithValue("@edQualification", edQualification);
                        command.Parameters.AddWithValue("@highqualification", highqualification);
                        command.Parameters.AddWithValue("@join", join);
                        command.Parameters.AddWithValue("@endpro", endpro);
                        command.Parameters.AddWithValue("@confirmation", confirmation);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Record inserted successfully.");
                        LoadData();


                        txtnicno.Clear();
                        txtemname.Clear();
                        txtbirth.Text = birth.ToString("yyyy-MM-dd HH:mm:ss");
                        txtages.Clear();
                        txtgen.Clear();
                        txtmail.Clear();
                        txtphone.Clear();
                        txtsal.Clear();
                        txteduquali.Clear();
                        txthquali.Clear();
                        txtjoin.Text = join.ToString("yyyy-MM-dd HH:mm:ss");
                        txtendpro.Text = endpro.ToString("yyyy-MM-dd HH:mm:ss");
                        txtconfirm.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding record: " + ex.Message);
                }
            }
        }

        private void Guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtnicno.Text = guna2DataGridView2.CurrentRow.Cells[0].Value.ToString();
                txtemname.Text = guna2DataGridView2.CurrentRow.Cells[1].Value.ToString();
                txtbirth.Text = guna2DataGridView2.CurrentRow.Cells[2].Value.ToString();
                txtages.Text = guna2DataGridView2.CurrentRow.Cells[3].Value.ToString();
                txtgen.Text = guna2DataGridView2.CurrentRow.Cells[4].Value.ToString();
                txtmail.Text = guna2DataGridView2.CurrentRow.Cells[5].Value.ToString();
                txtphone.Text = guna2DataGridView2.CurrentRow.Cells[6].Value.ToString();
                txtsal.Text = guna2DataGridView2.CurrentRow.Cells[7].Value.ToString();
                txteduquali.Text = guna2DataGridView2.CurrentRow.Cells[8].Value.ToString();
                txthquali.Text = guna2DataGridView2.CurrentRow.Cells[9].Value.ToString();
                txtjoin.Text = guna2DataGridView2.CurrentRow.Cells[10].Value.ToString();
                txtendpro.Text = guna2DataGridView2.CurrentRow.Cells[11].Value.ToString();
                txtconfirm.Text = guna2DataGridView2.CurrentRow.Cells[12].Value.ToString();
            }
        }

        private void Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Btndel_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView2.SelectedRows.Count > 0)
            {
                string nic = guna2DataGridView2.SelectedRows[0].Cells["NIC_No"].Value.ToString();
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
                    using (MySqlConnection connection = new MySqlConnection(connectionstring))
                    {
                        try
                        {
                            connection.Open();
                            string query = "DELETE FROM Staff WHERE NIC_No=@nic";
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@nic", nic);
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

        private void Btnup_Click(object sender, EventArgs e)
        {
            string nic = txtnicno.Text.Trim();
            string name = txtemname.Text.Trim();
            DateTime birth = DateTime.Now;
            string age = txtages.Text.Trim();
            string phone = txtphone.Text.Trim();
            string gender = txtgen.Text.Trim();
            string email = txtmail.Text.Trim();
            if (!decimal.TryParse(txtsal.Text.Trim(), out decimal salary))
            {
                MessageBox.Show("Invalid salary");
                return;
            }

            string edQualification = txteduquali.Text.Trim();
            string highqualification = txthquali.Text.Trim();
            DateTime join = DateTime.Now;
            DateTime endpro = DateTime.Now;
            string confirmation = txtconfirm.Text.Trim();

            string connectionstring = "server=localhost;user=root;database=Personalinfo;password=1234";
            using (MySqlConnection connection = new MySqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Staff SET NIC_No=@nic,Name=@name,Date_of_birth= @birth, Age=@age, Gender=@gender, Email=@email, Telephone=@phone, Salary= @salary, Education_qualification= @edQualification, Higher_Qualification=@highqualification, Date_of_joining=@join, End_of_the_probationary= @endpro, Confirmation_status=@confirmation";
                    using (MySqlCommand checkcommand = new MySqlCommand(query, connection))

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nic", nic);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@birth", birth);
                        command.Parameters.AddWithValue("@age", age);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@salary", salary);
                        command.Parameters.AddWithValue("@edQualification", edQualification);
                        command.Parameters.AddWithValue("@highqualification", highqualification);
                        command.Parameters.AddWithValue("@join", join);
                        command.Parameters.AddWithValue("@endpro", endpro);
                        command.Parameters.AddWithValue("@confirmation", confirmation);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully.");
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
                    MessageBox.Show("Error while updating: " + ex.Message);
                }
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtbirth.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd hh:MM:ss");
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtjoin.Text = dateTimePicker2.Value.ToString("yyyy-MM-dd hh:MM:ss");
        }

        private void DateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            txtendpro.Text = dateTimePicker3.Value.ToString("yyyy-MM-dd hh:MM:ss");
        }

        private void Btnhomee_Click(object sender, EventArgs e)
        {

        }

        private void Btnex_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Btncle_Click(object sender, EventArgs e)
        {
            txtnicno.Clear();
            txtemname.Clear();
            txtbirth.Clear();
            txtsal.Clear();
            txtmail.Clear();
            txtjoin.Clear();
            txtgen.Clear();
            txtendpro.Clear();
            txthquali.Clear();
            txteduquali.Clear();
            txtages.Clear();
            txtphone.Clear();
            txtconfirm.Clear();
        }

        private void Txtbirth_TextChanged(object sender, EventArgs e)
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
                    string query = "SELECT NIC_No, Name, Date_of_birth, Age, Gender, Email, Telephone, Salary, Education_qualification, Higher_Qualification,Date_of_joining, End_of_the_probationary, Confirmation_status FROM Staff WHERE NIC_No = @nic";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nic", txtsearch.Text);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtnicno.Text =reader["NIC_No"].ToString();
                                txtemname.Text = reader["Name"].ToString();
                                txtbirth.Text = Convert.ToDateTime(reader["Date_of_birth"]).ToString("yyyy-MM-dd");
                                txtsal.Text = reader["Salary"].ToString();
                                txtmail.Text = reader["Email"].ToString();
                                txtjoin.Text = Convert.ToDateTime(reader["Date_of_joining"]).ToString("yyyy-MM-dd");
                                txtgen.Text = reader["Gender"].ToString();
                                txtendpro.Text = Convert.ToDateTime(reader["End_of_the_probationary"]).ToString("yyyy-MM-dd");
                               txthquali.Text = reader["Higher_Qualification"].ToString();
                                txteduquali.Text = reader["Education_qualification"].ToString();
                                txtages.Text = reader["Age"].ToString();
                                txtphone.Text = reader["Telephone"].ToString();
                               txtconfirm.Text = reader["Confirmation_status"].ToString();

                            }
                            else
                            {
                                MessageBox.Show("Staff not found.");
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
    
    

