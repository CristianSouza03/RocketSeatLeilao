using Microsoft.EntityFrameworkCore;
using RocketseatLeilao.API.Entities;

namespace RocketseatLeilao.API.Repositorios;

public class RocketseatLeilaoDbContext : DbContext
{
    public RocketseatLeilaoDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
   
}
