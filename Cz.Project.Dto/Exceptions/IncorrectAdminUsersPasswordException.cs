using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Project.Dto.Exceptions
{
    public class IncorrectAdminUsersPasswordException : Exception
    {
        public IncorrectAdminUsersPasswordException(string message) : base(message)
        {
        }
    }
}
