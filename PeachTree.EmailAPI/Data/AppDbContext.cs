using Microsoft.EntityFrameworkCore;
using PeachTree.EmailAPI.Models;


namespace PeachTree.EmailAPI.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<EmailLogger> EmailLoggers { get; set; }

		
	}
	
}
