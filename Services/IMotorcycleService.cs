using MotorcycleApi.Models;
using MotorcycleApi.DTOs;


namespace MotorcycleApi.Services
{
    public interface IMotorcycleService 
    {
        Task<decimal> GetAveragePrice();
        Task<int> GetTotalStock ();
        Task<Motorcycle?> SellMotorcycle(int Id);
        Task<Motorcycle?> GetMostExpensive();
        Task<List<MotorcycleStockDTO>> GetMotorcyclesWithStock ();
        Task<List<MotorcyclePriceDTO>> GetExpensiveMotorcycles();
        Task<List<MotorcycleSummaryDTO>> GetCheapMotorcycles ();
        Task<List<MotorcycleDiscountDTO>> DiscountedMotorcyclePrice();
        Task<List<MotorcycleReportDTO>> TotalMotorcycle();

    }
}