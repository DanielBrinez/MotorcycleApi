using System;
using System.Collections.Generic;
using MotorcycleApi.DTOs;

namespace MotorcycleApi.DTOs
{
    public class MotorcycleTaxDTO
    {
        public string Name {get; set;} ="";

        public decimal OriginalPrice {get; set;}

        public decimal PriceWithTax {get; set;}
    }
}