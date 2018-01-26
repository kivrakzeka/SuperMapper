using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SuperMapper.Attributes;

namespace SuperMapper
{
    public class Mapper
    {
        public static TTarget Map<TSource, TTarget>(TSource source, Type MappingSource)
        {
            Type SourceType = typeof(TSource);
            Type TargetType = typeof(TTarget);

            var TargetReturnType = Activator.CreateInstance(typeof(TTarget));

            var TargetProperties = TargetType.GetProperties();
            var SourceProperties = SourceType.GetProperties();
            var MappingProps = MappingSource.GetProperties();

            foreach (PropertyInfo item in MappingProps)
            {
                var FieldAttribute = (MapperAttribute)item.GetCustomAttribute(typeof(MapperAttribute));

                if (FieldAttribute == null)
                    continue;

                if (typeof(TSource) == MappingSource)
                {
                    var prop = TargetProperties.Where(s => s.Name == FieldAttribute.FieldName).FirstOrDefault();

                    if (prop == null)
                        continue;

                    prop.SetValue(TargetReturnType, item.GetValue(source));
                }
                else
                {
                    var prop = SourceProperties.Where(s => s.Name == FieldAttribute.FieldName).FirstOrDefault();

                    if (prop == null)
                        continue;

                    item.SetValue(TargetReturnType, prop.GetValue(source));
                }
            }

            return (TTarget)TargetReturnType;
        }
    }
}