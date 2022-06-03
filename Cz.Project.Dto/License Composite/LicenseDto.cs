using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cz.Project.Dto
{
    public class LicenseDto : ComponentDto
    {
        public LicenseDto() { }

        public LicenseDto(string name, int code) : base(name, code) { }

        public override void AddChild(ComponentDto c)
        {
            throw new NotImplementedException();
        }

        public override IList<ComponentDto> GetChilds()
        {
            return null;
        }
    }
}
