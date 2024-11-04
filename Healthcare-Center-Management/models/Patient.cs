using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    internal class Patient : User
    {

        public Patient(int id, string name, string mobilePhone, char gender, Category category, List<Exam>? userExams = null)
        : base(id, name, mobilePhone, gender, category) 
        {
            UserExams = userExams ?? new List<Exam>(); 
        }


        public List<Exam>? UserExams { get; set; }

        public void AddExam(Exam exam)
        {
            if (UserExams == null)
                UserExams = new List<Exam>();

            UserExams.Add(exam);
        }

        //add a check by range

    }
}
