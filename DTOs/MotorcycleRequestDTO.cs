using System;
using System.Collections.Generic;

namespace MotorcycleApi.DTOs
{
    public class MotorcycleRequestDTO
    {
        public string Name {get; set;} ="";
        public int Stock {get; set;}
        public decimal Price {get; set;}
    }
}