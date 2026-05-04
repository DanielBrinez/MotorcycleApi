using Microsoft.EntityFrameworkCore;
using MotorcycleApi.Data;
using MotorcycleApi.Models;

namespace MotorcycleApi.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly MotorcycleContext _context;
        
        public MotorcycleService (MotorcycleContext context)
        {
            _context = context;
        }

    public async Task<List<MotorcycleResponseDTO>> GetAvailableMotorcycless()
        {
            var availableMotorcycles = await _context.Motorcycles.Where(f => f.Stock > 0).Select(f => new MotorcycleResponseDTO{Name = f.Name, Price = f.Price});
            return (availableMotorcycles);
        }

    public async Task<decimal> GetAveragePrice()
        {
            var findGet = await _context.Motorcycles.AverageAsync(f => f.Price);
            return (findGet);
        }

    public async Task<int> GetTotalStock ()
        {
            var sumGet = await _context.Motorcycles.SumAsync(s => s.Stock);
            return (sumGet);
        }

    public async Task<Motorcycle?> SellMotorcycle(int Id)
        {
            var sllMotorcycle = await _context.Motorcycles.FirstOrDefaultAsync(s => s.Id == Id);
            if(sllMotorcycle == null)
            {
                return (null);
            }
            else
            {
                sllMotorcycle.Stock = sllMotorcycle.Stock - 1;
                await _context.SaveChangesAsync();
                return(sllMotorcycle);
            }
        }

    public async Task<Motorcycle?> GetMostExpensive()
        {
            var findPrice = await _context.Motorcycles.OrderByDescending(f => f.Stock).FirstOrDefaultAsync();
            return(findPrice);
        }

    }
}