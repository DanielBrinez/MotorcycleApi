using MotorcycleApi.DTOs;
using MotorcycleApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorcycleApi.DTOs
{
    public class MotorcycleLowStockDTO
    {
        [Required]
        public string Name {get; set;} ="";

        [Range(0, double.MaxValue)]
        public int Stock {get; set;}
        public string StockStatus {get; set;}="";

    }
}