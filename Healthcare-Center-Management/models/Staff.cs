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
        public MedicalSpecialty Specialty { get;  set; }

        public Staff(string name, string mobilePhone, char gender, Category category, MedicalSpecialty specialty)
        : base( name, mobilePhone, gender, category)
        {
            Specialty = specialty; 
        }

        public Staff(int id, string name, string mobilePhone, char gender, Category category, MedicalSpecialty specialty)
        : base(id, name, mobilePhone, gender, category)
        {
            Specialty = specialty;
        }
    }
}
