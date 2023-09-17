using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Api.Models.StudentDto
{
    public class AddStudentDto
    {
        [Required(AllowEmptyStrings =false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string SurName { get; set; }
        [Range(1, int.MaxValue)]
        public int Age { get; set; }
    }
}