using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    public class Appointment
    {
        public int Id { get; private set; }
        public long DateAndTime { get; private set; } 
        public Patient Patient { get; private set; }
        public Staff Staff { get; set; }
        public string AdditionalDetails { get; set; }
        public List<Exam> Exams { get; private set; }  

        public Appointment(int id, long dateAndTime, Patient patient, Staff staff, List<Exam> exams, string additionalDetails = null)
        {
            Id = id;
            DateAndTime = dateAndTime;
            Patient = patient;
            Staff = staff;
            AdditionalDetails = additionalDetails;
            Exams = exams ?? new List<Exam>(); 

        }

        public Appointment(int id, long dateAndTime, Patient patient, Staff staff/*, Exam exam, bool isReturning*/)
        {
            Id = id;
            DateAndTime = dateAndTime;
            Patient = patient;
            Staff = staff;
            //Exam = exam;
        }

        public DateTime GetDateAndTimeAsDateTime()
        {
            return DateTimeOffset.FromUnixTimeSeconds(DateAndTime).UtcDateTime;
        }

        public void SetDateAndTimeFromDateTime(DateTime dateTime)
        {
            DateAndTime = ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
        }
    }
}
