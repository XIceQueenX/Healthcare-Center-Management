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
    public class PatientServices
    {
        private readonly PatientRepository _patientRepository;

        public PatientServices()
        {
            _patientRepository = new PatientRepository();
        }

        public List<Patient> GetPatients()
        {
            return _patientRepository.GetPatients();
        }

        public Patient GetPatientById(int id)
        {
            return _patientRepository.GetPatient(id);
        }

        public bool InsertPatient(Patient patient)
        {
            return _patientRepository.InsertPatient(patient);
        }

        public bool UpdatePatient(Patient patient)
        {
            return _patientRepository.UpdatePatient(patient);
        }

    }
}
