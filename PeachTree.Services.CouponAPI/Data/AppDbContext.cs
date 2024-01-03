using Microsoft.EntityFrameworkCore;
using PeachTree.Services.CouponAPI.Models;

namespace PeachTree.Services.CouponAPI.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            
        }

        public DbSet<Coupon> Coupons { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Coupon>().HasData(new Coupon
			{
				CouponId = 1,
				CouponCode = "20OFF",
				DiscountAmount = 20,
				MinAmount = 40

			});

			modelBuilder.Entity<Coupon>().HasData(new Coupon
			{
				CouponId = 2,
				CouponCode = "30OFF",
				DiscountAmount = 30,
				MinAmount = 60

			});
		}
	}
}
