using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.services
{
    internal class ExamServices
    {
        private readonly ExamsRepository _examRepository;

        public ExamServices()
        {
            _examRepository = new ExamsRepository();
        }

        public List<Exam> GetAllExams()
        {
            return _examRepository.GetAllExams();
        }


        public bool SaveExamForPatient(int patientId, int examId, int doctorId, int appointmentId, DateTime examDate)
        {
            return _examRepository.SaveExamForPatient(patientId, examId, doctorId, appointmentId, examDate);
        }

        public List<Exam> GetExamsByAppointmentId(int appointmentId)
        {
            return _examRepository.GetExamsByAppointmentId(appointmentId);
        }

        public List<PatientExam> GetPatientExamsById(int id)
        {
            return _examRepository.GetPatientExamsById(id);

        }
    }
}