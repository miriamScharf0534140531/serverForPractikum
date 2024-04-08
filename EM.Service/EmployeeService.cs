using AutoMapper;
using EM.Core.DTO;
using EM.Core.interfaces;
using EM.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRoleRepository _roleRepository;
        readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository,IRoleRepository roleRepository,IMapper mapper)
        {

            _employeeRepository = employeeRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;

        }
        public async Task<bool> Add(EmployeeDTO employee)
        {
            var em = _mapper.Map<Employee>(employee);
            _mapper.Map<List<EmployeeRole>>(em.Roles);
            em.Active= true;
       if(!IsValidEmployee(em))
                return false;
            return await _employeeRepository.Add(em);
        }
        private bool IsValidEmployee(Employee employee)
        {
            foreach (var e in employee.Roles)
            {
                if (!_roleRepository.IsExistId(e.RoleId).Result || employee.Roles.Count(r => r.Id == e.Id) > 1||e.JobStartDate.CompareTo(employee.StartDate)<0)
                    return false;
            }
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            return await _employeeRepository.Delete(id);
        }

        public  List<EmployeeDTO> GetAll()
        {

            var r=  _employeeRepository.GetAll().FindAll(x=>x.Active);
           // var roles=_roleRepository.GetEmployeeRoles();
           // r.ForEach(e=>e.EmployeeCharacteristics.Roles=roles.Result.FindAll(x=>x.EmployeeCharacteristicsId==e.Id));
            var eDTO = _mapper.Map<EmployeeDTO[]>(r).ToList();
            eDTO.ForEach(x => _mapper.Map<EmployeeRoleDTO[]>(x.Roles).ToList());
            return eDTO;
        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            if (_employeeRepository.IsExist(id).Result)
            {
                var em =await _employeeRepository.GetById(id);
                EmployeeDTO emDTO = _mapper.Map<EmployeeDTO>(em);
                return emDTO;
            }
            else return null;
        }

        public async Task<bool> Update(int id, EmployeeDTO employee)
        {
            var em = _mapper.Map<Employee>(employee);
            _mapper.Map<List<EmployeeRole>>(em.Roles);
            em.Active = true;
           if(!IsValidEmployee(em))
                return false;
            return _employeeRepository.Update(id, em).Result;
        }
    }
}
