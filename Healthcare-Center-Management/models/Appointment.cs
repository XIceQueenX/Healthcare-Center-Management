using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    /// <summary>
    /// Class Apppitnment
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Properties
        /// </summary>
        public int Id { get; private set; }
        public long DateAndTime { get; private set; }
        public Patient Patient { get; private set; }
        public Staff Staff { get; private set; }
        public string? AdditionalDetails { get; set; }

        /// <summary>
        /// Filled Constructor 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateAndTime"></param>
        /// <param name="patient"></param>
        /// <param name="staff"></param>
        /// <param name="additionalDetails"></param>
        public Appointment(int id, long dateAndTime, Patient patient, Staff staff, string additionalDetails = null)
        {
            Id = id;
            DateAndTime = dateAndTime;
            Patient = patient;
            Staff = staff;
            AdditionalDetails = additionalDetails;
        }
        
        /// <summary>
        /// Return the date and a human time
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateAndTimeAsDateTime()
            => DateTimeOffset.FromUnixTimeSeconds(DateAndTime).UtcDateTime;
    }
}
