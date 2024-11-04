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
        public int Id { get; private set; }
        public MedicalSpecialty Specialty { get; set; }        
       
    }
}
