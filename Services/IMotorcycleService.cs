using MotorcycleApi.Models;

namespace MotorcycleApi.Services
{
    public interface IMotorcycleService 
    {
        Task<List<Motorcycle>> GetAvailableMotorcycless();
        Task<decimal> GetAveragePrice();
        Task<int> GetTotalStock ();
        Task<Motorcycle?> SellMotorcycle(int Id);
        Task<Motorcycle?> GetMostExpensive();

    }
}