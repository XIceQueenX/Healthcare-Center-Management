using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    enum Category
    {
        Doctor,
        Nurse,
        Admin,
        Patient
    }

    internal class User
    {  
        private char gender;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Mobile_Phone { get; set; }
        public char Gender
        {
            get => gender;
            set => gender = char.ToUpper(value);
        }
        public Category Category { get; set; }
    }
}
