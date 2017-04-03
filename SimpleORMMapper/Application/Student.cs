using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper.Attibutes;

namespace Application
{
    public class Student
    {
        [AutoId]
        [EntityKey]
        public int Student_ID { private set; get; }
        public string Name { set; get; }
        public string EMail { set; get; }
        public string Mobile { set; get; }

        public string Address { set; get; }
        public string Gender { set; get; }
        [NonPersisted]
        private int Age
        {
            set { }
            get { return 18; }
        }
    }
}
