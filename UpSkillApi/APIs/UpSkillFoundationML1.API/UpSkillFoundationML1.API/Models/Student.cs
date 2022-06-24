using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UpSkillFoundationML1.API.Models
{
    public class Student
    {

        [Key]

        public int StudentId { get; set; }
        [Required(ErrorMessage = "Student name is must !!")]
        public string StudentName { get; set; }
        [Required]
        public string EducationStream {get; set;}
        [Required]
        [Range(1,12)]
        public int Standard { get; set; }
    }
}
