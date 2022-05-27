using Cz.Project.Dto;
using Cz.Project.Dto.Exceptions;
using Cz.Project.Repository;
using Cz.Project.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Project.Services
{
    public class UserService
    {
        /// <summary>
        /// Try to login user, if cant throws an error with detailed information
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public AdminUserDto Login(AdminUserDto user)
        {
            try
            {
                var userRepository = new UserRepository();

                var adminUser = userRepository.GetByName(user);

                if (adminUser == null)
                    throw new InvalidAdminUsersException("User not found");

                if (!HashHelper.VerifyHash(user.Password, HasAlgorithm.SHA512, adminUser.Password))
                    throw new IncorrectAdminUsersPasswordException($"Incorrect password for user name: {adminUser.Name} key: {adminUser.Key}");

                return adminUser;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IList<AdminUserDto> GetAll()
        {
            try
            {
                var userRepository = new UserRepository();
                return userRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AdminUserDto Add(AdminUserDto adminUserDto)
        {
            try
            {
                ValidatePassword(adminUserDto);

                var userRepository = new UserRepository();

                var user = userRepository.GetByName(adminUserDto);
                if (user != null)
                    throw new CustomException("El usuario ya existe");

                adminUserDto.Password = HashHelper.Encrypt(adminUserDto.Password, HasAlgorithm.SHA512, null);

                return userRepository.Add(adminUserDto);
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
                ValidatePassword(newUserValues);

                newUserValues.Password = HashHelper.Encrypt(newUserValues.Password, HasAlgorithm.SHA512, null);

                var userRepository = new UserRepository();
                return userRepository.Update(currentUser, newUserValues);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(AdminUserDto selectedUser)
        {
            var userRepository = new UserRepository();
            userRepository.Delete(selectedUser);
        }

        private void ValidatePassword(AdminUserDto adminUserDto)
        {
            var passwordLength = adminUserDto.Password.Length;

            if (passwordLength > 20 || passwordLength < 8)
            {
                throw new CustomException("La contraseña debe tener entre 8 y 20 caracteres");
            }
        }
    }
}
