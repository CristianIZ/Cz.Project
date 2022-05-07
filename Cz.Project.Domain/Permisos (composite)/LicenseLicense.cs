using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cz.Project.Domain
{
    public class LicenseLicense
    {
        [Required]
        public int IdPadre { get; set; }
        [Required]
        public int IdHijo { get; set; }
    }
}
