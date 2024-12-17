using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{


    public class User
    {
        private char gender;
        private string mobile_phone;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile_Phone
        {
            get ;
            set;
        }
        public char Gender
        {
            get => gender;
            set => gender = char.ToUpper(value);
        }
        public Category Category { get; set; }

        public User(int id, string name, string mobilePhone, char gender, Category category)
        {
            Id = id;
            Name = name;
            Mobile_Phone = mobilePhone;
            Gender = gender;
            Category = category;
        }

        public User( string name, string mobilePhone, char gender, Category category)
        {
            Name = name;
            Mobile_Phone = mobilePhone;
            Gender = gender;
            Category = category;
        }

        public User() { }
    }
}
