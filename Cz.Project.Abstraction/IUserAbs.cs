using System;

namespace Cz.Project.Abstraction
{
    public interface IUserAbs
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
