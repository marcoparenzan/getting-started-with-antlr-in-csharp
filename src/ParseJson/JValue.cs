using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParseJson
{
    public class JValue: JItem
    {
        string string_value;
        object[] objects_value;

        public static implicit operator JValue(string value)
        {
            return new JValue
            {
                string_value = value
            };
        }

        public static implicit operator JValue(object[] value)
        {
            return new JValue
            {
                objects_value = value
            };
        }
    }
}
