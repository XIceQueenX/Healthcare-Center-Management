using Gestao_Centro_Saude.repository;

namespace Gestao_Centro_Saude.models
{
    /// <summary>
    /// Patient Class
    /// </summary>
    public class Patient : User
    {
        /// <summary>
        /// Constructor to use when fetch data from db
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="gender"></param>
        public Patient(int id, string name, string mobilePhone, char gender)
           : base(id, name, mobilePhone, gender, new Category(1, "Pacient")) { }


        /// <summary>
        /// Constructor used to create new patients
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="gender"></param>
        public Patient(string name, string mobilePhone, char gender)
            : this(0, name, mobilePhone, gender) { }
    }

}
