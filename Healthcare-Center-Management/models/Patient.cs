using Gestao_Centro_Saude.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    internal class Patient : User
    {
        private static PatientRepository repo = new PatientRepository();

        public Patient() { }

        public Patient(int id, string name, string mobilePhone, char gender, List<Exam>? userExams = null)
        : base(id, name, mobilePhone, gender, Category.Patient)
        {
            if (userExams != null)
            {
                UserExams = userExams;
            }
        }

        public Patient(string name, string mobilePhone, char gender, Category category, List<Exam>? userExams = null)
       : base(name, mobilePhone, gender, category)
        {
            if (userExams != null)
            {
                UserExams = userExams;
            }
        }

        public List<Exam>? UserExams { get; set; }

        public void AddExam(Exam exam)
        {
            if (UserExams == null)
                UserExams = new List<Exam>();

            UserExams.Add(exam);
        }


        /**
         * Methods from DB
         * **/
        public static List<Patient> GetPatients()
        {
            return repo.GetPatients();
        }

        public static Patient GetPatientById(int id)
        {
            return repo.GetPatient(id);
        }
    }
}
