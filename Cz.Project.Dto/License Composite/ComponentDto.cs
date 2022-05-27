using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Project.Dto
{
    public abstract class ComponentDto
    {
        public string _name { get; set; }
        public int licenceCode { get; set; }

        public ComponentDto() { }

        public ComponentDto(string name, int code)
        {
            this._name = name;
            this.licenceCode = code;
        }

        public string Name { get { return _name; } }
        public abstract void AddChild(ComponentDto c);
        public abstract IReadOnlyCollection<ComponentDto> GetChilds();
    }
}
