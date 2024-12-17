using Gestao_Centro_Saude.repository;

namespace Gestao_Centro_Saude.models
{
    public class Patient : User
    {
        public List<Exam>? UserExams { get; set; }
        public Patient() { }

        public Patient(int id, string name, string mobilePhone, char gender, List<Exam>? userExams = null)
        : base(id, name, mobilePhone, gender, Category.Patient)
        {
            if (userExams != null)
            {
                UserExams = userExams;
            }
        }

        public Patient(string name, string mobilePhone, char gender, List<Exam>? userExams = null)
       : base(name, mobilePhone, gender, Category.Patient)
        {
            if (userExams != null)
                UserExams = userExams;
        }
    }


    public class PatientExamHistory
    {
        public int Id { get; set; }
        public List<Exam> UserExams { get; set; }

        public PatientExamHistory() { }

        public PatientExamHistory(List<Exam>? userExams = null)
        {
            if (userExams != null)
            {
                UserExams = userExams;
            }
        }

        // Methods for managing exam history:
        // - AddExam
        // - RemoveExam
        // - GetExamHistory
        // ...
    }
}
