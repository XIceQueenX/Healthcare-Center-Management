using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    internal class PatientExam
    {
        public int Id { get; private set; }
        public DateTime Date { get; set; } 
        public string Staff { get; set; }
        public string Diagnose { get; set; }

    }
}
