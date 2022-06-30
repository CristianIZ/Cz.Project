using Cz.Project.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cz.Project.Domain
{
    public class Word : KeyEntity
    {
        public Languaje Languaje { get; set; }
        public int IdLanguaje { get; set; }
        [Required]
        public string Translate { get; set; }
        [Required]
        public int Code { get; set; }
    }
}
