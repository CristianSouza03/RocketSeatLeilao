using RocketseatLeilao.API.Contratos;
using RocketseatLeilao.API.Entities;
using System;

namespace RocketseatLeilao.API.Repositorios.DataAcces;

public class OfferRepository : IOfferRepository
{
    private readonly RocketseatLeilaoDbContext _dbContext;
    public OfferRepository(RocketseatLeilaoDbContext dbContext) => _dbContext = dbContext;
    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);

        _dbContext.SaveChanges();
    }
   
}
