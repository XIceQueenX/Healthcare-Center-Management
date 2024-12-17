using Gestao_Centro_Saude.models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Gestao_Centro_Saude.repository
{
    internal class PatientRepository : DatabaseConfig
    {
        public Patient GetPatient(int id)
        {
            Patient patient = null;

            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string query = @"SELECT User.id,User.name, User.Mobile_Phone, User.Gender 
                         FROM User 
                         INNER JOIN Patient ON User.id = Patient.id 
                         WHERE User.id = @id";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);


                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        patient = new Patient(
                            id: reader.GetInt32(0),
                            name: reader.GetString(1),
                            mobilePhone: reader.GetString(2),
                            gender: reader.GetChar(3)
                         );

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return patient;
        }



        public List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();

            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string query = @"SELECT 
                                    User.id, 
                                    User.name, 
                                    User.mobile_phone, 
                                    User.gender 
                                    FROM User INNER JOIN Patient ON User.id = Patient.id;";

                    //TODO: Check use of 'using' on mysql commands
                    MySqlCommand command = new MySqlCommand(query, connection);

                    MySqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        patients.Add(new Patient(
                            id: reader.GetInt32(0),
                            name: reader.GetString(1),
                            mobilePhone: reader.GetString(2),
                            gender: reader.GetChar(3)
                        ));
                    }

                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return patients;

        }

        public bool InsertPatient(Patient patient)
        {
            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string userQuery = @"INSERT INTO User (name, mobile_phone, gender) 
                                     VALUES (@name, @mobilePhone, @gender)";
                    MySqlCommand userCommand = new MySqlCommand(userQuery, connection);
                    userCommand.Parameters.AddWithValue("@name", patient.Name);
                    userCommand.Parameters.AddWithValue("@mobilePhone", patient.Mobile_Phone);
                    userCommand.Parameters.AddWithValue("@gender", patient.Gender);

                    userCommand.ExecuteNonQuery();

                    int userId = Convert.ToInt32(new MySqlCommand("SELECT LAST_INSERT_ID();", connection).ExecuteScalar());

                    string patientQuery = @"INSERT INTO Patient (id) VALUES (@id)";
                    MySqlCommand patientCommand = new MySqlCommand(patientQuery, connection);
                    patientCommand.Parameters.AddWithValue("@id", userId);

                    patientCommand.ExecuteNonQuery();

                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while inserting patient: {ex.Message}");
                return false;
            }
        }
    }
}
