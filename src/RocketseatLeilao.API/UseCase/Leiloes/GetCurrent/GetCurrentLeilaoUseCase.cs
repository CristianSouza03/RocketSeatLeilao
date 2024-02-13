using RocketseatLeilao.API.Contratos;
using RocketseatLeilao.API.Entities;

namespace RocketseatLeilao.API.UseCase.Leiloes.GetCurrent;

public class GetCurrentLeilaoUseCase
{
    private readonly ILeilaoRepository _repository;

    public GetCurrentLeilaoUseCase(ILeilaoRepository repository ) => _repository = repository;
    public Auction? Execute() => _repository.GetCurrent();
   
    
}
