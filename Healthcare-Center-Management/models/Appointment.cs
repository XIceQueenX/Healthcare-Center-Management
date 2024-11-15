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
        public long Date { get; private set; } 
        public Patient Patient { get; private set; } 
        public Staff Staff { get; set; } 
        public Exam Exam { get; private set; }
        public bool isReturning { get; set; }

       
        public Appointment(int id, long date, Patient patient, Staff staff, Exam exam, bool isReturning)
        {
            Id = id;
            Date = date;
            Patient = patient;
            Staff = staff;
            Exam = exam;
            isReturning = isReturning;
        }

        public void RescheduleAppointment(long newDate)
        {
            //MISS Logic available dates
            if (newDate > Date)
            {
                Date = newDate;
            }
        }

    }
}
