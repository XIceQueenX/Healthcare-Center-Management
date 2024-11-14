using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    public enum MedicalSpecialty
    {
        Cardiology,     
        Dermatology,   
        Pediatrics,     
        Psychiatry,     
        Urgency,
        Surgery
    }

    internal class Staff:User
    {
        public MedicalSpecialty Specialty { get; private set; }

        public Staff(int id, string name, string mobilePhone, char gender, Category category, MedicalSpecialty specialty)
         : base(id, name, mobilePhone, gender, category)
        {
            Specialty = specialty; 
        }
        public void UpdateSpecialty(MedicalSpecialty newSpecialty)
        {
            Specialty = newSpecialty;
            Console.WriteLine($"Specialty updated to {Specialty}.");
        }

    }
}
