using Microsoft.EntityFrameworkCore;
using PeachTree.Services.ShoppingCart.Models;

namespace PeachTree.Services.ShoppingCart.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

        
	}
	
}
