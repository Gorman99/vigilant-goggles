using System.ComponentModel.DataAnnotations;

namespace WebApplication.Storage.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
    }
}