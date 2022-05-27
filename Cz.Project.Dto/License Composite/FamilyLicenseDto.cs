using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cz.Project.Dto
{
    public class FamilyLicenseDto : ComponentDto
    {
        private List<ComponentDto> childs;

        public FamilyLicenseDto(string name, int code) : base(name, code)
        {
            childs = new List<ComponentDto>();
        }

        public FamilyLicenseDto()
        {
            childs = new List<ComponentDto>();
        }

        public override void AddChild(ComponentDto c)
        {
            childs.Add(c);
        }

        public override IReadOnlyCollection<ComponentDto> GetChilds()
        {
            return childs.AsReadOnly();
        }
    }
}
