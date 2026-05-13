using Microsoft.EntityFrameworkCore;
using MotorcycleApi.Data;
using MotorcycleApi.Models;
using MotorcycleApi.DTOs;
using System.Linq;
using System.Net.Quic;

namespace MotorcycleApi.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly MotorcycleContext _context;
        
        public MotorcycleService (MotorcycleContext context)
        {
            _context = context;
        }

    public async Task<List<Motorcycle>> AllMotors()
        {
            var allMotorcycles = await _context.Motorcycles.ToListAsync();
            return allMotorcycles;
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
    
    public async Task<List<MotorcycleStockDTO>> GetMotorcyclesWithStock ()
        {
            var getMotor = await _context.Motorcycles.Where(g => g.Stock > 0)
            .Select(g => new MotorcycleStockDTO {Name = g.Name, Stock = g.Stock}).ToListAsync();
            return(getMotor);
        }

    public async Task<List<MotorcyclePriceDTO>> GetExpensiveMotorcycles()
        {
            var expensiveget = await _context.Motorcycles.Where(e => e.Price >= 20000000)
            .Select(e => new MotorcyclePriceDTO {Name = e.Name, Price = e.Price}).ToListAsync();
            return(expensiveget);
        
        }

    public async Task<List<MotorcycleSummaryDTO>> GetCheapMotorcycles ()
        {
            var getCheap = await _context.Motorcycles.Where(g => g.Price <= 15000000)
            .Select(g => new MotorcycleSummaryDTO {Name = g.Name, Stock = g.Stock, Price = g.Price})
            .OrderByDescending(g => g.Price).ToListAsync();
            return(getCheap);
        }

    public async Task<List<MotorcycleDiscountDTO>> DiscountedMotorcyclePrice()
        {
           var discountMotorcycle = await 
           _context.Motorcycles.Select(d => new MotorcycleDiscountDTO{Name = d.Name, DiscountedPrice = d.Price * 0.90m}).ToListAsync();
           return(discountMotorcycle);   
        }


    public async Task<List<MotorcycleReportDTO>> TotalMotorcycle()
        {
            var totalMotor = await _context.Motorcycles.Select(t => new MotorcycleReportDTO{Name = t.Name, Price = t.Price, Stock = t.Stock, TotalValue = t.Price * t.Stock})
            .OrderByDescending(t => t.TotalValue).ToListAsync();
            return(totalMotor);
        }

    public async Task<List<MotorcycleTopDTO>> GetTop3MostExpensive()
        {
            var find3Motorcycle = await _context.Motorcycles.Select(f => new MotorcycleTopDTO{Name = f.Name, Price = f.Price, Stock = f.Stock})
            .OrderByDescending(f => f.Price)
            .Take(3).ToListAsync();
            return(find3Motorcycle);
        }

    public async Task<Motorcycle> CreateMotorcycle(MotorcycleRequestDTO receivedMotorcycle)
        {
            var newMotorcycle = new Motorcycle
            {
                Name = receivedMotorcycle.Name,
                Price = receivedMotorcycle.Price,
                Stock = receivedMotorcycle.Stock
            };

                await _context.AddAsync(newMotorcycle);
                await _context.SaveChangesAsync();
                return newMotorcycle;   
        }
    public async Task<Motorcycle> UpdateMotorcycle (int Id, MotorcycleRequestDTO DeleteMotorcycle)
        {
            var UpdateData = await _context.Motorcycles.FirstOrDefaultAsync(f => f.Id == Id);
            if(UpdateData == null)
            {
                return (null);
            }
            else
            {
                UpdateData.Name = DeleteMotorcycle.Name;
                UpdateData.Price = DeleteMotorcycle.Price;
                UpdateData.Stock = DeleteMotorcycle.Stock;
                await _context.SaveChangesAsync();
                return UpdateData;
            }
        }

    public async Task<Motorcycle> DeleteMotorcycle(int Id)
        {
            var findDelete = await _context.Motorcycles.FirstOrDefaultAsync(f => f.Id == Id);
            if(findDelete == null)
            {
                return null;
            }
            else
            {
                _context.Motorcycles.Remove(findDelete);
                await _context.SaveChangesAsync();
                return findDelete;
            }
        }

    public async Task<List<MotorcycleLowStockDTO>> CalculateMotorcycle()
        {
            var findCalculate = await _context.Motorcycles.Where(f => f.Stock <= 3)
            .Select(f=> new MotorcycleLowStockDTO{Name =f.Name, Stock = f.Stock, StockStatus = f.Stock == 1 ? "Critico" : "Bajo" }).ToListAsync();
            return(findCalculate);
        }
    public async Task<List<MotorcycleTaxDTO>> CalculatePrice()
        {
            var calculateMPrice = await _context.Motorcycles.Select(
                c => new MotorcycleTaxDTO{Name = c.Name, OriginalPrice = c.Price, PriceWithTax = c.Price * 1.19m}).ToListAsync();
            return calculateMPrice;
        }
    public async Task<Motorcycle?> RestockMotorcycle(int Id, int quantity)
        {
            var restockMotorcycle = await _context.Motorcycles.FirstOrDefaultAsync(r => r.Id == Id);
            if(restockMotorcycle == null)
            {
                return null;
            }
            else
            {
                restockMotorcycle.Stock += quantity;
                await _context.SaveChangesAsync();
                return restockMotorcycle;
            }
        }
    public async Task<List<InventoryStatusDTO>> GetAllInventory ()
        {
            var findAllInventory = await _context.Motorcycles.Select
            (f => new InventoryStatusDTO{Name = f.Name, Price = f.Price, Status = f.Price > 30000000 && f.Stock > 5 ? 
            "Premium disponible" : f.Price > 30000000 && f.Stock <= 5 ? "Premium Agotándose" : f.Price <= 30000000 && f.Stock > 5 ? "Estandar disponible"
            : "Estándar agotandose"}).ToListAsync();
            return findAllInventory;
        }
    public async Task<Motorcycle?> RegisterSale(int Id, SaleRequestDTO saveMotorcycle)
        {
            var findRegister = await _context.Motorcycles.FirstOrDefaultAsync(f => f.Id == Id);
            if(findRegister == null)
            {
                return null;
            }
            else if(saveMotorcycle.Quantity > findRegister.Stock)
            {
                return null;
            }
            else
            {
                findRegister.Stock -= saveMotorcycle.Quantity;
                await _context.SaveChangesAsync();
                return findRegister;
            }
        }
    }
}

