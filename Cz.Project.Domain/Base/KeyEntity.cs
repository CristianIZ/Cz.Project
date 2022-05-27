using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cz.Project.Domain.Base
{
    public class KeyEntity : BaseEntity
    {
        [Required]
        [StringLength(36)]
        public string Key { get; set; }
    }
}
