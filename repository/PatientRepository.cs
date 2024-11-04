using Gestao_Centro_Saude.models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

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
                            gender: reader.GetChar(3),
                            category: Category.Patient
                         );

                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");

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
                          category: Category.Patient,
                          userExams: userExams
                      );
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
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
                            gender: reader.GetChar(3),
                            category: Category.Patient
                        ));
                    }

                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }

            return patients;

        }
    }
}
