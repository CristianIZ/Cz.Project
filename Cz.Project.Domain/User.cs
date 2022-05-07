using System;
using System.ComponentModel.DataAnnotations;

namespace Cz.Project.Domain
{
    public class User : KeyEntity
    {
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
    }
}
