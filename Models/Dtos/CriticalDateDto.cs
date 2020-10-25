using System;

namespace Calendar.Models.Dtos
{
    public class CriticalDateDto
    {
      
        public DateTime Begin { get; set; }
        
        public DateTime End { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        public string Name { get; set; }

    }
}