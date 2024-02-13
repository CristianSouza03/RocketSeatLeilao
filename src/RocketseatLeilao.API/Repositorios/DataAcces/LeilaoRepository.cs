using Microsoft.EntityFrameworkCore;
using RocketseatLeilao.API.Contratos;
using RocketseatLeilao.API.Entities;

namespace RocketseatLeilao.API.Repositorios.DataAcces;

public class LeilaoRepository : ILeilaoRepository
{
    private readonly RocketseatLeilaoDbContext _dbContext;
    public LeilaoRepository(RocketseatLeilaoDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = DateTime.Now;

        return _dbContext
            .Auctions
            .Include(Auction => Auction.Items)
            .FirstOrDefault(Auction => today >= Auction.Starts);
    }
}
