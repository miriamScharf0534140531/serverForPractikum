using EM.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Core.interfaces
{
    public interface IRoleService
    {
        public Task<string> GetById(int id);
        public Task<List<Role>> GetRoles();
    }
}
