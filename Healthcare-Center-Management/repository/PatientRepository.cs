using Gestao_Centro_Saude.models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Gestao_Centro_Saude.repository
{

    /// <summary>
    /// Class the holds to logic to communicate with db
    /// </summary>
    internal class PatientRepository : DatabaseConfig, ILogger
    {
        string TAG = "PatientRepository";


        /// <summary>
        /// GEt a patient by his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                Log(TAG, ex.Message);
            }

            return patient;
        }


        /// <summary>
        /// Get All Pacients
        /// </summary>
        /// <returns></returns>
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
                Log(TAG, ex.Message);
            }

            return patients;

        }

        //Add new Patients do DB
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
                Log(TAG, ex.Message);
                return false;
            }
        }

        //Update pateint info
        public bool UpdatePatient(Patient patient)
        {
            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();


                    string query = "UPDATE User " +
                                    "SET name = @Name, mobile_phone = @MobilePhone, gender = @Gender " +
                                    "WHERE Id = @Id";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    
                        command.Parameters.AddWithValue("@Name", patient.Name);
                        command.Parameters.AddWithValue("@MobilePhone", patient.Mobile_Phone);
                        command.Parameters.AddWithValue("@Gender", patient.Gender);
                        command.Parameters.AddWithValue("@Id", patient.Id);

                        int rowsAffected = command.ExecuteNonQuery();

                }
                return true;

            }
            catch (Exception ex)
            {
                Log(TAG, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Print out the output on debug
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        public void Log(string tag, string message)
        {
            Debug.WriteLine($"{tag} {message}");
        }

    }
}

