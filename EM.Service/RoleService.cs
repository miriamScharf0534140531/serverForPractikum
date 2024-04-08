using EM.Core.interfaces;
using EM.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Service
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public Task<string> GetById(int id)
        {
            if (_roleRepository.IsExistId(id).Result)
                return _roleRepository.GetById(id);
            return null;
        }

        public Task<List<Role>> GetRoles()
        {
            return _roleRepository.GetRoles();
        }
    }
}
