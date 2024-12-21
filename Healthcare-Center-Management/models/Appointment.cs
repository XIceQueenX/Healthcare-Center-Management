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
        public Staff Staff { get; private set; }
        public string AdditionalDetails { get; set; }

        public Appointment(int id, long dateAndTime, Patient patient, Staff staff, string additionalDetails = null)
        {
            Id = id;
            DateAndTime = dateAndTime;
            Patient = patient ?? throw new ArgumentNullException(nameof(patient));
            Staff = staff ?? throw new ArgumentNullException(nameof(staff));
            AdditionalDetails = additionalDetails;
        }
                
        public DateTime GetDateAndTimeAsDateTime()
            => DateTimeOffset.FromUnixTimeSeconds(DateAndTime).UtcDateTime;

        public void SetDateAndTimeFromDateTime(DateTime dateTime)
            => DateAndTime = ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
    }
}
