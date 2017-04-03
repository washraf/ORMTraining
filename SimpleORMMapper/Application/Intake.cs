using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper.Attibutes;

namespace Application
{
    public class Intake
    {
        [EntityKey]
        [AutoId]
        public int Intake_ID { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public string Times { set; get; }
        public int Course_ID { set; get; }

        public virtual Course course { set; get; }
        public float Price { set; get; }
    }
}
