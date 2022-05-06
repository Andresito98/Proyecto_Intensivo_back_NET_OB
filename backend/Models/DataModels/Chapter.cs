using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.DataModels
{
    public class Chapter: BaseEntity
    {
        public int CourseID { get; set; }
        public virtual Course Course { get; set; } = new Course();


        public string List  = string.Empty;
    }
}
