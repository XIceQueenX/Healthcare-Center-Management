using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    internal class Appointment
    {
        public int Id { get; private set; }
        public DateTime Date { get; set; } 
        public Patient Patient { get; set; } 
        public Staff Staff { get; set; } 
        public Exam Exam { get; set; }
        public bool isReturning { get; set; }
    }
}
