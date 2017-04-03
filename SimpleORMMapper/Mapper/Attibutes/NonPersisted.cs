using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Attibutes
{
    /// <summary>
    /// Marks properties as not mapped to database
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NonPersisted : Attribute
    {

    }
}
