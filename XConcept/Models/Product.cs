using System.ComponentModel.DataAnnotations;

namespace XConcept.Models
{
    public class Product
    {
        [Key]
        public int  Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        
    }
}