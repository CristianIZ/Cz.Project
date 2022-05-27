using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cz.Project.Domain.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
