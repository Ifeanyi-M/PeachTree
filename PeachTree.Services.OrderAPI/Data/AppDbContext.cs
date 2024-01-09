using Microsoft.EntityFrameworkCore;
using PeachTree.Services.OrderAPI.Models;

namespace PeachTree.Services.OrderAPI.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        
	}
	
}
