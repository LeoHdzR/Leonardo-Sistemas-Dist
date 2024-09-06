using Microsoft.EntityFrameworkCore;
using SoapApi.Models;
using SoapApi.Infrastructure.Entities;

namespace SoapApi
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Book> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
             
        }

       
    }
}
