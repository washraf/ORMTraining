//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpecificRepository.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lesson
    {
        public int Lesson_ID { get; set; }
        public string LessonName { get; set; }
        public string LessonContent { get; set; }
        public string Video { get; set; }
        public int Course_ID { get; set; }
    
        public virtual Course Course { get; set; }
    }
}
