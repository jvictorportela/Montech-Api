using Microsoft.EntityFrameworkCore;
using Montech.Api.Models;

namespace Montech.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Empresa> Empresa { get; set; }
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
}
