using Gestao_Centro_Saude.models;
using Gestao_Centro_Saude.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Centro_Saude.services
{
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
