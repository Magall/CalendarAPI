using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace Calendar.Models
{
    public class CriticalDate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Begin { get; set; }
        [Required]
        public DateTime End { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Name { get; set; }
        [ForeignKey("Name")]
        public Department Dep { get; set; }

    }
}