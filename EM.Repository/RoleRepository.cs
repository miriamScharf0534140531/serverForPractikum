using EM.Core;
using EM.Core.interfaces;
using EM.Core.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Data
{
    public class RoleRepository : IRoleRepository
    {
        private readonly EMContext _context;
        public RoleRepository(EMContext context)
        {
            _context = context;
        }
        public async Task<bool> IsExistId(int id)
        {
            return await _context.Roles.AnyAsync(role => role.Id == id);
        }
        public async Task<string> GetById (int id){ 
            var x= await _context.Roles.FirstAsync(x=>x.Id==id);
            return x.Name;
        }
        public async Task<List<Role>> GetRoles()
        {
            return  _context.Roles.ToList();
        }

    }
}
