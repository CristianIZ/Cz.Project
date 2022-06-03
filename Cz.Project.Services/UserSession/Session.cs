using Cz.Project.Dto;
using Cz.Project.Dto.Exceptions;
using Cz.Project.Repository;
using Cz.Project.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Project.Services.UserSession
{
    public class Session
    {
        private static Session _session;

        public AdminUserDto AdminUser { get; set; }
        public DateTime LoginDate { get; set; }

        public static object _lock = new object();

        private Session() { }

        public static Session GetInstance()
        {
            return _session;
        }

        public static void Login(AdminUserDto userDto)
        {
            if (_session != null)
                throw new CustomException("Ya existe una sesion iniciada");

            lock (_lock)
            {
                try
                {
                    var userRepository = new UserRepository();
                    var adminUser = userRepository.GetByName(userDto);

                    if (adminUser == null)
                        throw new InvalidAdminUsersException("User not found");

                    if (!HashHelper.VerifyHash(userDto.Password, HasAlgorithm.SHA512, adminUser.Password))
                        throw new IncorrectAdminUsersPasswordException($"Incorrect password for user name: {adminUser.Name} key: {adminUser.Key}");

                    _session = new Session();
                    _session.AdminUser = userDto;
                    _session.LoginDate = DateTime.Now;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void LogOut(AdminUserDto userDto)
        {
            lock (_lock)
            {
                if (_session != null)
                    _session = null;
                else
                    throw new CustomException("No existe niguna sesion iniciada");
            }
        }
    }
}
