using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Project.Domain
{
    public class License : BaseEntity
    {
        public int IdUser{ get; set; }
        public string Name { get; set; }
        public bool HasChilds { get; set; }
    }
}
