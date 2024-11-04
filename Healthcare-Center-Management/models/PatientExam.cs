using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    internal class PatientExam
    {
        public PatientExam(int id, string name, DateTime date, string staff, string diagnosis)
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

        public DateTime Date { get; set; } 
        public string Staff { get; set; }
        public string Diagnosis { get; set; }

    }
}
