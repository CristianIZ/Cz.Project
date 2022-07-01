using AutoMapper;
using Cz.Project.Domain;
using Cz.Project.Dto;
using Cz.Project.Dto.Exceptions;
using Cz.Project.Repository.MappingProfile;
using SQL = Cz.Project.SQLContext;
using System;
using System.Collections.Generic;

namespace Cz.Project.Repository
{
    public class UserRepository
    {
        public IMapper mapper;

        public UserRepository()
        {
            var config = new AutoMapperProfiles();
            mapper = new Mapper(config.MapConfig());
        }

        public IList<AdminUserDto> GetAll()
        {
            try
            {
                var sqAdminlUsersContext = new SQL.AdminUsersContext();
                return mapper.Map<IList<AdminUserDto>>(sqAdminlUsersContext.GetAll());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AdminUserDto GetByName(AdminUserDto adminUserDto)
        {
            try
            {
                var sqlAdminlUsersContext = new SQL.AdminUsersContext();
                
                var adminUser = sqlAdminlUsersContext.GetByName(mapper.Map<AdminUsers>(adminUserDto));
                return mapper.Map<AdminUserDto>(adminUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(AdminUserDto adminUserDto)
        {
            try
            {
                var sqlUserContext = new SQL.AdminUsersContext();

                var adminUser = mapper.Map<AdminUsers>(adminUserDto);
                adminUser.Key = Guid.NewGuid().ToString();
                sqlUserContext.Add(adminUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(AdminUserDto adminUserDto)
        {
            try
            {
                var sqlUserContext = new SQL.AdminUsersContext();
                var adminUser = mapper.Map<AdminUsers>(adminUserDto);
                var userToDelete = sqlUserContext.GetByName(adminUser);
                sqlUserContext.Delete(userToDelete);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AdminUserDto Update(AdminUserDto currentUser, AdminUserDto newUserValues)
        {
            try
            {
                var sqlUserContext = new SQL.AdminUsersContext();
                
                var userCheck = sqlUserContext.GetByName(mapper.Map<AdminUsers>(newUserValues));

                if (userCheck != null)
                    throw new CustomException("El usuario ya existe");

                var userToChange = sqlUserContext.GetByName(mapper.Map<AdminUsers>(currentUser));

                userToChange.Name = newUserValues.Name;
                userToChange.Password = newUserValues.Password;

                sqlUserContext.Update(userToChange);
                return mapper.Map<AdminUserDto>(userToChange);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
