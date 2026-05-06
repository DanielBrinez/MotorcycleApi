using System;
using System.Collections.Generic;

namespace MotorcycleApi.DTOs
{
    public class MotorcycleDiscountDTO
    {
        public string Name {get; set;} = "";
        public decimal DiscountedPrice {get; set;}
    }
}