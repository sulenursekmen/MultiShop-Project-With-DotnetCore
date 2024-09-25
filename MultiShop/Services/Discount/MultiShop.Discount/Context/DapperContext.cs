using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SULLENS\\SQLEXPRESS;Initial Catalog=MultiShopDiscountDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
