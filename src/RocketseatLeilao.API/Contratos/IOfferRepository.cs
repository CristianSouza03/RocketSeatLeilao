using RocketseatLeilao.API.Entities;

namespace RocketseatLeilao.API.Contratos;

public interface IOfferRepository
{
    void Add(Offer offer);
}
