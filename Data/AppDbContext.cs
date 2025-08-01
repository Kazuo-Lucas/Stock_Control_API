using Microsoft.EntityFrameworkCore;
using ControleEstoqueApi.Models;

namespace ControleEstoqueApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
