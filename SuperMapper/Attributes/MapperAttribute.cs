using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMapper.Attributes
{
    public class MapperAttribute : Attribute
    {
        public string FieldName { get; set; }

        public MapperAttribute(string field)
        {
            this.FieldName = field;
        }
    }
}
