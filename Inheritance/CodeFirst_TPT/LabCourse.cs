using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst_TPT
{
    [Table("LabCourse")]
    public class LabCourse : Course
    {
        public string Location { get; set; }
    }
}