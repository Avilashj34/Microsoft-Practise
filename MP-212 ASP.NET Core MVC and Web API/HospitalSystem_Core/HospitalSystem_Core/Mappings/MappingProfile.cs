using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalSystem_Core.Models;
using HospitalSystem_Core.ViewModels;

namespace HospitalSystem_Core.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterVm, Register>();
            CreateMap<Register, RegisterVm>();

            CreateMap<DoctorVm,Doctors>();
            CreateMap<Doctors,DoctorVm>();
        }
    }
}
