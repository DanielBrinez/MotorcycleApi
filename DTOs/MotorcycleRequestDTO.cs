using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorcycleApi.DTOs
{
    public class MotorcycleRequestDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name {get; set;} ="";

        [Range(0, double.MaxValue)]
            public int Stock {get; set;}

        [Range(1, 999999999)] 
        public decimal Price {get; set;}
    }
}