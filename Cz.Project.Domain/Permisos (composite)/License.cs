using Cz.Project.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Project.Domain
{
    public class License : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
