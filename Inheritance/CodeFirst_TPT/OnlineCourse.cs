using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst_TPT
{
    [Table("OnlineCourse")]
    public class OnlineCourse : Course
    {
        public bool SelfPaced { get; set; }
    }
}