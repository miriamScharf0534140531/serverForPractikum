using AutoMapper;
using EM.Core.DTO;
using EM.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Core
{
    public class EMProfile : Profile
    {
        public EMProfile()
        {

            CreateMap<EmployeeDTO, Employee>().ForMember(x => x.Active, y => y.Ignore()).ReverseMap();

            CreateMap<EmployeeRoleDTO, EmployeeRole>().ReverseMap();


        }

    }
}
