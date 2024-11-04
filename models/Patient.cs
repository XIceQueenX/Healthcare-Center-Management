using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    internal class Patient:User
    {
        public List<Exam>? UserExams { get; set; }

        public void AddExam(Exam exam)
        {
            if (UserExams == null)
                UserExams = new List<Exam>();
            
            UserExams.Add(exam);
        }

        /*public List<Exam> GetExamsByDateRange(DateTime startDate, DateTime endDate)
        {
            if (UserExams == null) return new List<Exam>();

            return UserExams.Where(e => e.Date >= startDate && e.Date <= endDate).ToList();
        }*/

    }
}
