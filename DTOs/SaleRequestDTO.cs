using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorcycleApi.DTOs
{
    public class SaleRequestDTO
    {
        [Required]
        public int MotorcycleId {get; set;}

        [Range(0, double.MaxValue)]
        public int Quantity {get; set;}
    }
}