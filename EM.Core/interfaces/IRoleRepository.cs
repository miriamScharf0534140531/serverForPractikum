using EM.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Core.interfaces
{
    public interface IRoleRepository
    {
        public Task<string> GetById(int id);
        public Task<bool> IsExistId(int id);
        public Task<List<EmployeeRole>> GetEmployeeRoles();
    }
}
