using Gestao_Centro_Saude.repository;

namespace Gestao_Centro_Saude.models
{
    public class Patient : User
    {
        public Patient(int id, string name, string mobilePhone, char gender)
           : base(id, name, mobilePhone, gender, new Category(1, "Pacient")) { }

        public Patient(string name, string mobilePhone, char gender)
            : this(0, name, mobilePhone, gender) { }
    }

}
