using Gestao_Centro_Saude.models;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gestao_Centro_Saude.repository
{
    internal class PatientRepository : DatabaseConfig
    {

        //Get patient by id examas and diagnoses
        //List of patinets basic info

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
                Consol.WriteLine($"Exception: {ex.Message}");

            }

            return patient;
        }


        public Patient GetPatientExams(int id)
        {
            Patient patient = null;
            List<Exam> userExams = new List<Exam>();

            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string query = @"
                                    SELECT 
                                        u.id AS user_id, 
                                        u.name AS user_name, 
                                        u.mobile_phone AS user_mobile, 
                                        u.gender AS user_gender, 
                                        e.name AS exam_name, 
                                        pe.date AS exam_date, 
                                        pe.diagnosis AS exam_diagnosis
                                    FROM 
                                        user u
                                    INNER JOIN 
                                        patient p ON p.id = u.id
                                    INNER JOIN 
                                        patientexam pe ON pe.idPatient = u.id
                                    INNER JOIN 
                                        exam e ON e.id = pe.idExam
                                    WHERE u.id = {id}
                                    ORDER BY 
                                        pe.date DESC;";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        patient = new Patient(
                          id: reader.GetInt32(0),
                          name: reader.GetString(1),
                          mobilePhone: reader.GetString(2),
                          gender: reader.GetChar(3),
                          userExams: userExams
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


        public List<PatientExam> GetPatientExamsById(int id)
        {
            List<PatientExam> userExams = new List<PatientExam>();

            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string query = @"
                            SELECT 
                                pe.id AS exam_id,
                                e.name AS exam_name, 
                                pe.date AS exam_date, 
                                u.name AS staff_name,
                                pe.diagnosis AS exam_diagnosis
                            FROM 
                                patientexam pe
                            INNER JOIN 
                                exam e ON e.id = pe.idExam
                            INNER JOIN 
                                user u ON u.id = pe.doctor
                            WHERE 
                                pe.idPatient = @id 
                            ORDER BY 
                                pe.date DESC;
                            ";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var patientExam = new PatientExam(
                                    id: reader.GetInt32(0),
                                    name: reader.GetString(1),
                                    date: 0005673291,
                                    staff: reader.GetString(3),
                                    diagnosis: reader.GetString(4)
                                );

                                userExams.Add(patientExam);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return userExams;
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

                    using (var transaction = connection.BeginTransaction())
                    {
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
                       
                        transaction.Commit();
                    }
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
