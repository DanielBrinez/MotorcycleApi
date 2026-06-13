using MotorcycleApi.Models;
using MotorcycleApi.DTOs;
using MotorcycleApi.Services;

namespace MotorcycleApi.DTOs
{
    public class CalculateStockDTO
    {
        public string Name {get; set;} ="";
        public int Stock {get; set;}
        public string StockStatus {get; set;}="";
    }
}