using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    /// <summary>
    /// User ckass
    /// </summary>
    public class User
    {
        /// <summary>
        /// Properties
        /// </summary>
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


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="gender"></param>
        /// <param name="category"></param>
        public User(int id, string name, string mobilePhone, char gender, Category category)
        {
            Id = id;
            Name = name;
            Mobile_Phone = mobilePhone;
            Gender = gender;
            Category = category;
        }

       
    }
}
