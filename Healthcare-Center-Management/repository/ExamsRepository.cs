using Gestao_Centro_Saude.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.repository
{
    /// <summary>
    /// Class the holds to logic to communicate with db
    /// </summary>
    internal class ExamsRepository : DatabaseConfig, ILogger
    {
        string TAG = "ExamsRepository";

        public List<Exam> GetAllExams()
        {
            var exams = new List<Exam>();

            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string query = "SELECT * FROM Exam";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exams.Add(new Exam
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name"),
                                Description = reader.GetString("description"),
                                Cost = reader.GetFloat("cost")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(TAG, ex.Message);
            }

            return exams;
        }

        public void SaveExam(int examId, int patientId, int specialtyId, DateTime date)
        {
            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    //TODO: fix it
                    int staffId = 1;

                    if (staffId == -1)
                    {
                        throw new Exception("No available staff found for the selected specialty.");
                    }

                    string query = @"
                INSERT INTO patientexam (idExam, idPatient, doctor, date)
                VALUES (@examId, @patientId, @staffId, @date)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@examId", examId);
                        command.Parameters.AddWithValue("@patientId", patientId);
                        command.Parameters.AddWithValue("@staffId", staffId);
                        command.Parameters.AddWithValue("@date", date.Ticks);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Exam scheduled successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to schedule the exam.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(TAG, ex.Message);
            }
        }

        public bool SaveExamForPatient(int patientId, int examId, int doctorId, int appointmentId, DateTime examDate)
        {
            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();
                    string query = @"
                INSERT INTO patientexam (idPatient, idExam, doctor, date, idAppointment)
                VALUES (@patientId, @examId, @doctorId, @examDate, @appointmentId);
            ";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@patientId", patientId);
                        command.Parameters.AddWithValue("@examId", examId);
                        command.Parameters.AddWithValue("@doctorId", doctorId);
                        command.Parameters.AddWithValue("@examDate", examDate);
                        command.Parameters.AddWithValue("@appointmentId", appointmentId);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Log(TAG, ex.Message);
                return false;
            }
        }


        public List<Exam> GetExamsByAppointmentId(int appointmentId)
        {
            List<Exam> exams = new List<Exam>();

            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    e.id AS exam_id, 
                    e.name AS exam_name, 
                    e.description AS exam_description, 
                    e.cost AS exam_cost
                FROM patientexam pe
                JOIN Exam e ON pe.idExam = e.id
                WHERE pe.idAppointment = @appointmentId;
            ";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@appointmentId", appointmentId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                exams.Add(new Exam(
    id: reader.GetInt32("exam_id"),
    name: reader.GetString("exam_name"),
    description: reader.GetString("exam_description"),
    cost: (double)reader.GetDecimal("exam_cost")
));

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(TAG, ex.Message);

            }

            return exams;
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
                                pe.idExam AS exam_id,
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
 diagnosis: reader.IsDBNull(reader.GetOrdinal("exam_diagnosis"))
                                       ? "No diagnosis"
                                       : reader.GetString("exam_diagnosis"));

                                userExams.Add(patientExam);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(TAG, ex.Message);
            }
            return userExams;
        }

        public void Log(string tag, string message)
        {
           Console.WriteLine($"{tag} {message}");
        }
    }
}
