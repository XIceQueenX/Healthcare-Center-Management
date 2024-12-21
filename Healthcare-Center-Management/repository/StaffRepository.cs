using Gestao_Centro_Saude.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.repository
{

    /// <summary>
    /// Class the holds to logic to communicate with db
    /// </summary>
    internal class StaffRepository : DatabaseConfig, ILogger
    {
        string TAG = "StaffRepository";


        /// <summary>
        /// Get all specialization on db
        /// </summary>
        /// <returns></returns>
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
                Log(TAG, ex.Message);
            }

            return specializations;
        }

        /// <summary>
        /// Get a staff speciality
        /// </summary>
        /// <param name="specialtyId"></param>
        /// <returns></returns>
        public List<Staff> GetStaffBySpecialty(int specialtyId)
        {
            List<Staff> staffList = new List<Staff>();

            try
            {
                using (MySqlConnection connection = CreateConnection())
                {
                    connection.Open();

                    string query = @"
            SELECT 
                s.id, 
                u.name, 
u.gender,
u.mobile_phone,

                s.idSpecialization, 
                sp.description AS specialty_name,
                sp.id AS specialty_id,

                s.category_id, 
                c.name AS category_name
            FROM Staff s
            INNER JOIN User u ON s.id = u.id
            INNER JOIN Specialization sp ON s.idSpecialization = sp.id
            INNER JOIN Category c ON s.category_id = c.id
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

                                int specializationId = reader.GetInt32("specialty_id");
                                string specialtyName = reader.GetString("specialty_name");

                                int categoryId = reader.GetInt32("category_id");
                                string categoryName = reader.GetString("category_name");

                                Category category = new Category(categoryId, categoryName);
                                Specialization specialization = new Specialization(specializationId, specialtyName);

                                Staff staff = new Staff(
                                    id: staffId,
                                    name: staffName,
                                    mobilePhone: reader.GetString("mobile_phone"), 
                                    gender: reader.GetChar("gender"), 
                                    category: category,
                                    specialty: specialization
                                );
                                staffList.Add(staff);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log("GetStaffBySpecialty", ex.Message);
            }

            return staffList;
        }

        /// <summary>
        /// Print in debug the output
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        public void Log(string tag, string message)
        {
            Debug.WriteLine($"{tag} {message}");
        }
    }
}
