using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.services
{
    /// <summary>
    /// Class resposible for call the method of db (Same method of repositories, but only them assignature
    /// </summary>
    internal class AppointmentServicescs
    {
        private readonly AppointmentRepository _appointmentRepository;

        public AppointmentServicescs()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        public bool InsertAppointment(Appointment appointment)
        {
            return _appointmentRepository.InsertAppointment(appointment);
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAllAppointments();
        }


        public List<Appointment> GetAppointmentsByUserId(int id)
        {
            return _appointmentRepository.GetAppointmentsByUserId(id);
        }


        public bool UpdateAdditionalDetails(int idAppointment, string additionalDetails)
        {
            return _appointmentRepository.UpdateAdditionalDetails(idAppointment, additionalDetails);
        }
    }
}
