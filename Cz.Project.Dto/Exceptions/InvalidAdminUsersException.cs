using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Project.Dto.Exceptions
{
    public class InvalidAdminUsersException : Exception
    {
        public InvalidAdminUsersException(string message) : base(message)
        {
        }
    }
}
