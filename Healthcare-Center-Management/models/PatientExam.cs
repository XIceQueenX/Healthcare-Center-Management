using Gestao_Centro_Saude.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    internal class PatientExam
    {
        private static PatientRepository repo = new PatientRepository();

        public PatientExam(int id, string name, long date, string staff, string diagnosis)
        {
            Id = id;
            Name = name;
            Date = date;
            Staff = staff;
            Diagnosis = diagnosis;
        }

        PatientExam() { }

        public int Id { get; private set; }
        public string Name { get; set; }

        public long Date { get; set; } 
        public string Staff { get; set; }
        public string Diagnosis { get; set; }

        public void UpdateDiagnosis(string newDiagnosis)
        {
            Diagnosis = newDiagnosis;
            Console.WriteLine("Success");
        }

        public static List<PatientExam> GetExamsById(int id)
        {
            return repo.GetPatientExamsById(id);
        }


    }
}
