using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.services;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.repository
{
    /// <summary>
    /// Class the manage the sql apppoitmnent part
    /// </summary>
    internal class AppointmentRepository : DatabaseConfig, ILogger
    {
        string TAG = "AppointmentRepo";

        /// <summary>
        /// Insert a new appointment into db
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update the addiotinal field of appointments
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="newDetails"></param>
        /// <returns></returns>
        public bool UpdateAdditionalDetails(int appointmentId, string newDetails)
        {
            bool success = false;

            string query = @"
                UPDATE Appointment
                SET additional_details = @newDetails
                WHERE id = @appointmentId;";

            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newDetails", newDetails);
                        command.Parameters.AddWithValue("@appointmentId", appointmentId);

                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating details: {ex.Message}");
            }

            return false;
        }

        /// <summary>
        /// List all appointment in db
        /// </summary>
        /// <returns></returns>
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
                    {

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string? additionalDetails = reader["additional_details"] as string;

                                Appointment appointment = new Appointment(
                                 id: reader.GetInt16("appointment_id"),
                                 dateAndTime: reader.GetInt64("appointment_date"),
                                 additionalDetails: additionalDetails ?? "",
                                 patient: new Patient(
                                     id: reader.GetInt16("patient_id"),
                                     name: reader.GetString("patient_name"),
                                     mobilePhone: reader.GetString("patient_mobilePhone"),
                                     gender: Convert.ToChar(reader["patient_gender"])
                                 ),
                                 staff: new Staff(
                                     id: reader.GetInt16("staff_id"),
                                     name: reader.GetString("staff_name"),
                                     mobilePhone: reader.GetString("staff_mobilePhone"),
                                     gender: reader.GetChar("staff_gender"),
                                     category: new Category(
                                         id: reader.GetInt16("staff_category_id"),
                                         description: reader.GetString("category_name")
                                     ),
                                     specialty: new Specialization(
                                         id: reader.GetInt16("staff_specialty_id"),
                                         description: reader.GetString("staff_specialty")
                                     )
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
                Log(TAG, ex.Message);
            }

            return appointments;
        }


        /// <summary>
        /// Get apppointments by user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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
                                string? additionalDetails = reader["additional_details"] as string;

                                Appointment appointment = new Appointment(
                                 id: reader.GetInt16("appointment_id"),
                                 dateAndTime: reader.GetInt64("appointment_date"),
                                 additionalDetails: additionalDetails ?? "",
                                 patient: new Patient(
                                     id: reader.GetInt16("patient_id"),
                                     name: reader.GetString("patient_name"),
                                     mobilePhone: reader.GetString("patient_mobilePhone"),
                                     gender: Convert.ToChar(reader["patient_gender"])
                                 ),
                                 staff: new Staff(
                                     id: reader.GetInt16("staff_id"),
                                     name: reader.GetString("staff_name"),
                                     mobilePhone: reader.GetString("staff_mobilePhone"),
                                     gender: reader.GetChar("staff_gender"),
                                     category: new Category(
                                         id: reader.GetInt16("staff_category_id"),
                                         description: reader.GetString("category_name")
                                     ),
                                     specialty: new Specialization(
                                         id: reader.GetInt16("staff_specialty_id"),
                                         description: reader.GetString("staff_specialty")
                                     )
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
                Log(TAG, ex.Message);
            }

            return appointments;
        }

        /// <summary>
        /// Return all the appointments of the day
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Return all the appointments of the day
        /// </summary>
        /// <returns></returns>
        public List<Appointment> GetAppointmentsOfTheDay()
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
             WHERE DATE(FROM_UNIXTIME(a.date)) = CURDATE()
             ORDER BY a.date ASC;";


                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string? additionalDetails = reader.GetString("additional_details");

                                Appointment appointment = new Appointment(
                                id: reader.GetInt16("appointment_id"),
                                dateAndTime: reader.GetInt64("appointment_date"),
                                additionalDetails: additionalDetails,
                                patient: new Patient(
                                    id: reader.GetInt16("patient_id"),
                                    name: reader.GetString("patient_name"),
                                    mobilePhone: reader.GetString("patient_mobilePhone"),
                                    gender: Convert.ToChar(reader["patient_gender"])
                                ),
                                staff: new Staff(
                                    id: reader.GetInt16("staff_id"),
                                    name: reader.GetString("staff_name"),
                                    mobilePhone: reader.GetString("staff_mobilePhone"),
                                    gender: reader.GetChar("staff_gender"),
                                    category: new Category(
                                        id: reader.GetInt16("staff_category_id"),
                                        description: reader.GetString("category_name")
                                    ),
                                    specialty: new Specialization(
                                        id: reader.GetInt16("staff_specialty_id"),
                                        description: reader.GetString("staff_specialty")
                                    )
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
                Log(TAG, ex.Message);
            }

            return appointments;

        }
        public void Log(string tag, string message)
        {
            Debug.WriteLine(message, tag);
        }
    }
}
