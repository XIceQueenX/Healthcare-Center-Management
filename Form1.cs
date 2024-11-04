using Gestao_Centro_Saude.models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Gestao_Centro_Saude
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=localhost;database=healthcare_center;user=root;password=root;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT User.name, User.Mobile_Phone, User.Gender " +
                                     "FROM User " +
                                     "INNER JOIN Patient ON User.id = Patient.id " +
                                     "LIMIT 1";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    MySqlDataReader reader = command.ExecuteReader();
                        
                            if (reader.Read())
                            {
                                Patient patient = new Patient
                                {
                                    Name = reader["name"].ToString(),
                                    Mobile_Phone = reader["Mobile_Phone"].ToString(),
                                    Gender = Convert.ToChar(reader["Gender"]),
                                };

                                label1.Text = $"Name: {patient.Name}\n" +
                                              $"Mobile Phone: {patient.Mobile_Phone}\n" +
                                              $"Gender: {patient.Gender}\n";
                            }
                           
                        
                    
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

    }
}
