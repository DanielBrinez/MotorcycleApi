using System;
using System.Collections.Generic;

namespace MotorcycleApi.DTOs
{
    public class MotorcycleReportDTO
    {
        public string Name {get; set;} = "";
        public decimal Price {get; set;}
        public int Stock {get; set;}
        public decimal TotalValue {get; set;}
    }
}