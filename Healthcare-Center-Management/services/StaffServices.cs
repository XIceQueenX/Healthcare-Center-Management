using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.services
{

    /// <summary>
    /// Class resposible for call the method of db (Same method of repositories, but only them assignature
    /// </summary>
    internal class StaffServices
    {
        private readonly StaffRepository _staffRepository;

        public StaffServices()
        {
            _staffRepository = new StaffRepository();
        }

        public List<Specialization> GetAllSpecializations()
        {
            return _staffRepository.GetAllSpecializations();
        }

        public List<Staff> GetStaffBySpecialty(int idSpeciality)
        {
            return _staffRepository.GetStaffBySpecialty(idSpeciality);
        }
    }
}
