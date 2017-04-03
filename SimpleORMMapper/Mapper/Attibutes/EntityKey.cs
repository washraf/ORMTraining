using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Attibutes
{
    /// <summary>
    /// Marking an Attribute As key
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EntityKey : Attribute
    {
    }
}
