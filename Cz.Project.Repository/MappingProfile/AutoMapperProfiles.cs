using AutoMapper;
using Cz.Project.Domain;
using Cz.Project.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Project.Repository.MappingProfile
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() { }

        public MapperConfiguration MapConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminUsers, AdminUserDto>(MemberList.None)
                    .ForMember(dest => dest.Name, src => src.MapFrom(v => v.Name))
                    .ForMember(dest => dest.Password, src => src.MapFrom(v => v.Password));

                // Dto to Domain
                cfg.CreateMap<AdminUserDto, AdminUsers>(MemberList.None)
                    .ForMember(dest => dest.Name, src => src.MapFrom(v => v.Name))
                    .ForMember(dest => dest.Password, src => src.MapFrom(v => v.Password));
            });
        }
    }
}
