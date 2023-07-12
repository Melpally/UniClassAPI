using Microsoft.EntityFrameworkCore; 
using System.ComponentModel.DataAnnotations;
namespace UniClass.Models
{
    public class Major
    {
        [Key]
        public Guid Id {get; set;}
        public string Name {get; set;} = null!;
        
        //one-to-many with students
        public List<Student>? Students {get; set;}
    }
}