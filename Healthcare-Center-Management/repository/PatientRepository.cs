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
                    checkCommand.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

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
                Console.WriteLine($"Exception while scheduling appointment: {ex.Message}");
                return false;
            }
        }

        public List<Specialization> GetAllSpecializations()
        {
            List<Specialization> specializations = new List<Specialization>();

            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string query = "SELECT id, description FROM Specialization";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            specializations.Add(new Specialization(
                                id: reader.GetInt32("id"),
                                description: reader.GetString("description")
                            ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching specializations: {ex.Message}");
            }

            return specializations;
        }


        public List<Staff> GetStaffBySpecialty(MedicalSpecialty specialty)
        {
            var staffList = new List<Staff>();

            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    id, name, mobilePhone, gender, category, specialty 
                FROM 
                    staff 
                WHERE 
                    specialty = @specialty";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@specialty", (int)specialty); 

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var staff = new Staff(
                                    id: reader.GetInt32(0),
                                    name: reader.GetString(1),
                                    mobilePhone: reader.GetString(2),
                                    gender: reader.GetChar(3),
                                    category: (Category)reader.GetInt32(4),
                                      specialty: (MedicalSpecialty)reader.GetInt32(5) 
                                );

                                staffList.Add(staff);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching staff by specialty: {ex.Message}");
            }

            return staffList;
        }



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
                Console.WriteLine($"Exception while inserting appointment: {ex.Message}");
                return false;
            }
        }

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
                Console.WriteLine($"Error fetching exams: {ex.Message}");
            }

            return exams;
        }
        

        public List<Staff> GetStaffBySpecialty(int specialtyId)
        {
            List<Staff> staffList = new List<Staff>();

            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT s.id, u.name, s.idSpecialization
                FROM Staff s
                INNER JOIN User u ON s.id = u.id
                WHERE s.idSpecialization = @specialtyId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@specialtyId", specialtyId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int staffId = reader.GetInt32("id");
                                string staffName = reader.GetString("name");
                                int staffSpecialtyId = reader.GetInt32("idSpecialization");

                                MedicalSpecialty staffSpecialty = (MedicalSpecialty)staffSpecialtyId;

                                Staff staff = new Staff(staffId, staffName, "unknown", 'M', Category.Nurse, staffSpecialty);
                                staffList.Add(staff);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching staff by specialty: {ex.Message}");
            }

            return staffList; 
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
                Console.WriteLine($"Error saving exam: {ex.Message}");
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
                Console.WriteLine($"Error saving exam for patient: {ex.Message}");
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
                Console.WriteLine($"Error fetching exams for appointment {appointmentId}: {ex.Message}");
            }

            return exams;
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
    a.additional_details AS additional_details,  -- Fetch the new column

                    p.id AS patient_id, 
                    s.id AS staff_id, 
                    sp.description AS staff_specialty,
                    pu.name AS patient_name, 
                    pu.mobile_phone AS patient_mobilePhone, 
                    pu.gender AS patient_gender,
                    su.name AS staff_name, 
                    su.mobile_phone AS staff_mobilePhone, 
                    su.gender AS staff_gender
                FROM Appointment a
                JOIN Patient p ON a.idPatient = p.id
                JOIN Staff s ON a.idStaff = s.id
                JOIN Specialization sp ON s.idSpecialization = sp.id
                JOIN User pu ON p.id = pu.id  -- Join to get Patient info from User table
                JOIN User su ON s.id = su.id  -- Join to get Staff info from User table
                ORDER BY a.date DESC;
            ";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Appointment currentAppointment = null;

                        while (reader.Read())
                        {
                            int appointmentId = reader.GetInt32(reader.GetOrdinal("appointment_id"));

                            if (currentAppointment == null || currentAppointment.Id != appointmentId)
                            {
                                string staffSpecialty = reader.IsDBNull(reader.GetOrdinal("staff_specialty")) ? null : reader.GetString("staff_specialty");
                                long appointmentUnixTimestamp = reader.GetInt64(reader.GetOrdinal("appointment_date"));

                                MedicalSpecialty specialty = MedicalSpecialty.Psychiatry; 
                                if (!string.IsNullOrEmpty(staffSpecialty))
                                {
                                    Enum.TryParse(staffSpecialty, out specialty);
                                }


                                List<Exam> exams = GetExamsByAppointmentId(appointmentId);


                                currentAppointment = new Appointment(
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
                                        category: Category.Doctor, 
                                        specialty: specialty 
                                    ),
                                     exams: new List<Exam>() 
                                );
                           

                                appointments.Add(currentAppointment);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching appointments: {ex.Message}");
            }

            return appointments;
        }
    }
}
