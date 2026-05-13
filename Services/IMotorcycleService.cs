using MotorcycleApi.Models;
using MotorcycleApi.DTOs;


namespace MotorcycleApi.Services
{
    public interface IMotorcycleService 
    {
        Task<decimal> GetAveragePrice();
        Task<int> GetTotalStock ();
        Task<List<Motorcycle>> AllMotors();
        Task<Motorcycle?> SellMotorcycle(int Id);
        Task<Motorcycle?> GetMostExpensive();
        Task<List<MotorcycleStockDTO>> GetMotorcyclesWithStock ();
        Task<List<MotorcyclePriceDTO>> GetExpensiveMotorcycles();
        Task<List<MotorcycleSummaryDTO>> GetCheapMotorcycles ();
        Task<List<MotorcycleDiscountDTO>> DiscountedMotorcyclePrice();
        Task<List<MotorcycleReportDTO>> TotalMotorcycle();
        Task<List<MotorcycleTopDTO>> GetTop3MostExpensive();
        Task<Motorcycle> CreateMotorcycle(MotorcycleRequestDTO receivedMotorcycle);
        Task<Motorcycle> UpdateMotorcycle (int Id, MotorcycleRequestDTO DeleteMotorcycle);
        Task<Motorcycle> DeleteMotorcycle(int id);
        Task<List<MotorcycleLowStockDTO>> CalculateMotorcycle();
        Task<List<MotorcycleTaxDTO>> CalculatePrice();
        Task<Motorcycle?> RestockMotorcycle(int Id, int quantity);
        Task<List<InventoryStatusDTO>> GetAllInventory ();
        Task<Motorcycle?> RegisterSale(int Id, SaleRequestDTO saveMotorcycle);

    }
}