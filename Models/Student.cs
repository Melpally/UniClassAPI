using Microsoft.EntityFrameworkCore; 
using System.ComponentModel.DataAnnotations;
namespace UniClass.Models
{
    public class Student
    {
        [Key]
        public Guid Id {get; set;}
        public string FullName {get; set;} = null!;
        public Funding Funding {get; set;}
        public DateTime DateOfBirth {get; set;}
        
        //one-to-many relationship wuth course
        public Guid? MajorId {get; set;}
        public Major? Major {get; set;}
    }
   
}