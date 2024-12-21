using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.repository
{
    
    internal class AppointmentRepository : DatabaseConfig, ILogger
    {

        string TAG = "AppointmentRepo";
        public bool InsertAppointment(Appointment appointment)
        {
            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string query = @"INSERT INTO Appointment (idStaff, idPatient, date) 
                            VALUES (@idStaff, @idPatient, @date)";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("@idStaff", appointment.Staff.Id);
                    command.Parameters.AddWithValue("@idPatient", appointment.Patient.Id);
                    command.Parameters.AddWithValue("@date", appointment.DateAndTime);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Log(TAG, ex.Message);
                return false;
            }
        }

        public bool ScheduleAppointment(int staffId, int patientId, DateTime date)
        {
            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string checkQuery = @"SELECT COUNT(*) 
                                  FROM Appointment 
                                  WHERE idStaff = @staffId 
                                  AND idPatient = @patientId 
                                  AND date = @date";

                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@staffId", staffId);
                    checkCommand.Parameters.AddWithValue("@patientId", patientId);
                    checkCommand.Parameters.AddWithValue("@date", date);

                    int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (existingCount > 0)
                    {
                        Console.WriteLine("Appointment already exists for this staff, patient, and date.");
                        return false;
                    }

                    string insertQuery = @"INSERT INTO Appointment (idStaff, idPatient, date) 
                                   VALUES (@staffId, @patientId, @date)";

                    MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@staffId", staffId);
                    insertCommand.Parameters.AddWithValue("@patientId", patientId);
                    insertCommand.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Log(TAG, ex.Message);
                return false;
            }
        }


        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string query = @"
            SELECT 
                a.id AS appointment_id, 
                a.date AS appointment_date,
                a.additional_details AS additional_details,
                s.category_id AS staff_category_id, 
                c.name AS category_name, 
                sp.description AS staff_specialty,
                sp.id AS staff_specialty_id,

                p.id AS patient_id, 
                pu.name AS patient_name, 
                pu.mobile_phone AS patient_mobilePhone, 
                pu.gender AS patient_gender,
                s.id AS staff_id, 
                su.name AS staff_name, 
                su.mobile_phone AS staff_mobilePhone, 
                su.gender AS staff_gender
            FROM Appointment a
            JOIN Patient p ON a.idPatient = p.id
            JOIN Staff s ON a.idStaff = s.id
            JOIN Category c ON s.category_id = c.id
            JOIN Specialization sp ON s.idSpecialization = sp.id
            JOIN User pu ON p.id = pu.id
            JOIN User su ON s.id = su.id
            ORDER BY a.date DESC;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int appointmentId = reader.GetInt32(reader.GetOrdinal("appointment_id"));

                            long appointmentUnixTimestamp = reader.GetInt64(reader.GetOrdinal("appointment_date"));

                            // Category and Specialization mapping
                            Category staffCategory = new Category(
                                id: reader.GetInt32("staff_category_id"),
                                description: reader.GetString("category_name")
                            );

                            Specialization staffSpecialization = new Specialization(
                                  id: reader.GetInt32("staff_specialty_id"), // Use the correct column for the specialization ID
            description: reader.GetString("staff_specialty")
                            );

                            // ExamService placeholder
                            ExamServices examServices = new ExamServices();
                            List<Exam> exams = examServices.GetExamsByAppointmentId(appointmentId);

                            // Construct Appointment
                            Appointment appointment = new Appointment(
                                id: appointmentId,
                                dateAndTime: appointmentUnixTimestamp,
                                patient: new Patient(
                                    id: reader.GetInt32("patient_id"),
                                    name: reader.GetString("patient_name"),
                                    mobilePhone: reader.GetString("patient_mobilePhone"),
                                    gender: reader.GetChar("patient_gender")
                                ),
                                staff: new Staff(
                                    id: reader.GetInt32("staff_id"),
                                    name: reader.GetString("staff_name"),
                                    mobilePhone: reader.GetString("staff_mobilePhone"),
                                    gender: reader.GetChar("staff_gender"),
                                    category: staffCategory,
                                    specialty: staffSpecialization
                                )
                            );

                            appointments.Add(appointment);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("GetAllAppointments", ex.Message);
            }

            return appointments;
        }

        public List<Appointment> GetAppointmentsByUserId(int userId)
        {
            List<Appointment> appointments = new List<Appointment>();

            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string query = @"
            SELECT 
                a.id AS appointment_id, 
                a.date AS appointment_date,
                a.additional_details AS additional_details,
                s.category_id AS staff_category_id, 
                c.name AS category_name, 
                sp.description AS staff_specialty,
                sp.id AS staff_specialty_id,

                p.id AS patient_id, 
                pu.name AS patient_name, 
                pu.mobile_phone AS patient_mobilePhone, 
                pu.gender AS patient_gender,
                s.id AS staff_id, 
                su.name AS staff_name, 
                su.mobile_phone AS staff_mobilePhone, 
                su.gender AS staff_gender
            FROM Appointment a
            JOIN Patient p ON a.idPatient = p.id
            JOIN Staff s ON a.idStaff = s.id
            JOIN Category c ON s.category_id = c.id
            JOIN Specialization sp ON s.idSpecialization = sp.id
            JOIN User pu ON p.id = pu.id
            JOIN User su ON s.id = su.id
            WHERE pu.id = @userId
            ORDER BY a.date DESC;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int appointmentId = reader.GetInt32(reader.GetOrdinal("appointment_id"));

                                long appointmentUnixTimestamp = reader.GetInt64(reader.GetOrdinal("appointment_date"));

                                // Category and Specialization mapping
                                Category staffCategory = new Category(
                                    id: reader.GetInt32("staff_category_id"),
                                    description: reader.GetString("category_name")
                                );

                                Specialization staffSpecialization = new Specialization(
                                    id: reader.GetInt32("staff_specialty_id"), 
                                    description: reader.GetString("staff_specialty")
                                );

                                // ExamService placeholder
                                ExamServices examServices = new ExamServices();
                                List<Exam> exams = examServices.GetExamsByAppointmentId(appointmentId);

                                // Construct Appointment
                                Appointment appointment = new Appointment(
                                    id: appointmentId,
                                    dateAndTime: appointmentUnixTimestamp,
                                    patient: new Patient(
                                        id: reader.GetInt32("patient_id"),
                                        name: reader.GetString("patient_name"),
                                        mobilePhone: reader.GetString("patient_mobilePhone"),
                                        gender: reader.GetChar("patient_gender")
                                    ),
                                    staff: new Staff(
                                        id: reader.GetInt32("staff_id"),
                                        name: reader.GetString("staff_name"),
                                        mobilePhone: reader.GetString("staff_mobilePhone"),
                                        gender: reader.GetChar("staff_gender"),
                                        category: staffCategory,
                                        specialty: staffSpecialization
                                    )
                                );

                                appointments.Add(appointment);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("GetAppointmentsByUserId", ex.Message);
            }

            return appointments;
        }


        public void Log(string tag, string message)
        {
            Debug.WriteLine(tag, message);
        }
    }
}
