﻿using System.ComponentModel.DataAnnotations;

namespace XConcept.Models
{
    public class Product
    {
        [Key]
        public int  Id { get; set; }
        [Required]
        public string Description { get; set; }
       [Required]
        public string Category { get; set; }
        
    }
}