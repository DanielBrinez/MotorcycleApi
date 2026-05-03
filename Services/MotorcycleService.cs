using Microsoft.EntityFrameworkCore;
using MotorcycleApi.Models;
using MotorcycleApi.Data;

namespace MotorcycleApi.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly MotorcycleContext _context;

        public MotorcycleService(MotorcycleContext context)
        {
            _context = context;
        }
    
    public async Task<List<Motorcycle>> GetAll()
        {
            return await (_context.Motorcycles.ToListAsync());
        }

    public async Task <Motorcycle?> GetById(int Id)
        {
            var findId = await _context.Motorcycles.FirstOrDefaultAsync(f => f.Id == Id);
            if(findId == null)
            {
                return(null);
            }
            else
            {
                return(findId);
            }
        }
    
    public async Task <Motorcycle?> GetPost(Motorcycle receivedesmotorcycles)
        {
            receivedesmotorcycles.Id = await _context.Motorcycles.CountAsync() + 1;
            _context.Motorcycles.Add(receivedesmotorcycles);
            await _context.SaveChangesAsync();
            return(receivedesmotorcycles);
        }
    
    public async Task <Motorcycle?> GetPut(int Id, Motorcycle UpdatedMotorcycle)
        {
            var updatePut = await _context.Motorcycles.FirstOrDefaultAsync(f => f.Id == Id);
            if(updatePut == null)
            {
                return(null);
            }
            else
            {
                 updatePut.Name = UpdatedMotorcycle.Name;
                 updatePut.Stock = UpdatedMotorcycle.Stock;
                 updatePut.Price = UpdatedMotorcycle.Price;
                 await _context.SaveChangesAsync();
                 return(updatePut);
                
            }
        }

    public async Task <Motorcycle?> GetDelete(int Id)
        {
            var findDelete = await _context.Motorcycles.FirstOrDefaultAsync(f => f.Id == Id);
            if(findDelete == null)
            {
                return (null);
            }
            else
            {
                _context.Remove(findDelete);
                await _context.SaveChangesAsync();
                return(findDelete);
            }
        }
    }
}