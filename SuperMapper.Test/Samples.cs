using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMapper.Attributes;

namespace SuperMapper.Test
{
    public class Samples
    {
        public void ConvertEntityToModel()
        {
            //TEST DATA
            var data = new EntityClass
            {
                IDX = 1,
                FIRST_NAME = "Servet",
                LAST_NAME = "Atasoy"
            };

            var result = Mapper.Map<EntityClass, ResponseModel>(data, typeof(ResponseModel));
        }
    }

    /// <summary>
    /// THIS IS YOUR DATABASE ENTITY CLASS
    /// </summary>
    public class EntityClass
    {
        public int IDX { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
    }

    /// <summary>
    /// THIS IS YOUR RESPONSE MODEL. YOU HAVE TO SET AS A ATTRIBUTE EVERY PROPERTY OF CLASS WHICH NAMES ARE ENTITY CLASS PROPERTY NAME
    /// </summary>
    public class ResponseModel
    {
        [Mapping("IDX")]
        public int Id { get; set; }

        [Mapping("FIRST_NAME")]
        public string FirstName { get; set; }

        [Mapping("LAST_NAME")]
        public string LastName { get; set; }
    }
}
