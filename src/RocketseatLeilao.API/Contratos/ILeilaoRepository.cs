using RocketseatLeilao.API.Entities;

namespace RocketseatLeilao.API.Contratos;

public interface ILeilaoRepository
{
    Auction? GetCurrent();
}
