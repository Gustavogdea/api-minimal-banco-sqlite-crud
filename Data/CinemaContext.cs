using CinemaPipocando.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaPipocando.Data;

public class CinemaContext : DbContext
{
    public DbSet<Filme> filmes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=db_filmes.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}
