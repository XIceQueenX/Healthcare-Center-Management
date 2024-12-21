using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.models
{
    /// <summary>
    /// Staff class
    /// </summary>
    public class Staff:User
    {
        /// <summary>
        /// Properties
        /// </summary>
        public Specialization speciality { get;  set; }
        public Category category { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="gender"></param>
        /// <param name="category"></param>
        /// <param name="specialty"></param>
        public Staff(int id, string name, string mobilePhone, char gender, Category category, Specialization specialty)
        : base(id, name, mobilePhone, gender, category)
        {
            speciality = specialty;
            category = category;
        }
    }
}
