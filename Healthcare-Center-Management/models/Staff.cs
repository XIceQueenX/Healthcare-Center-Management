using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    public class Staff:User
    {
        public Specialization speciality { get;  set; }
        public Category category { get; set; }

        public Staff(int id, string name, string mobilePhone, char gender, Category category, Specialization specialty)
        : base(id, name, mobilePhone, gender, category)
        {
            speciality = specialty;
            category = category;
        }
    }
}
