using System.ComponentModel.DataAnnotations;
namespace Calendar.Models
{
    public class Department
    {
        [Key]
        public string Name { get; set; }
        
    }
}