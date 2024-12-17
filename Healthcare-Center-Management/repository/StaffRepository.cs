using Gestao_Centro_Saude.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.repository
{
    internal class StaffRepository : DatabaseConfig
    {
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


    }
}
