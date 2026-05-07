using Microsoft.EntityFrameworkCore;
using MotorcycleApi.Models;

namespace MotorcycleApi.Data
{
    public class MotorcycleContext : DbContext
    {
        public MotorcycleContext(DbContextOptions <MotorcycleContext> options) : base (options)
        {
            
        }
        public DbSet<Motorcycle> Motorcycles {get; set;}
        public DbSet<User> Users { get; set; }

    }
}