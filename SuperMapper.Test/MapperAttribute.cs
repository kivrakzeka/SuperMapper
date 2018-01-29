using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMapper.Attributes
{
    public class MappingAttribute : Attribute
    {
        public string FieldName { get; set; }

        public MappingAttribute(string field)
        {
            this.FieldName = field;
        }
    }
}
