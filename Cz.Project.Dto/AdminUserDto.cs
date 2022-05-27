using Cz.Project.Abstraction;
using System;

namespace Cz.Project.Dto
{
    public class AdminUserDto : IUserAbs
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"User: {Name}";
        }
    }
}
