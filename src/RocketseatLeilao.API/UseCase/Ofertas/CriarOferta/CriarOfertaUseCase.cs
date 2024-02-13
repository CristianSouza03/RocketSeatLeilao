using RocketseatLeilao.API.Comunicação.Requests;
using RocketseatLeilao.API.Contratos;
using RocketseatLeilao.API.Entities;
using RocketseatLeilao.API.Serviços;

namespace RocketseatLeilao.API.UseCase.Ofertas.CriarOferta;

public class CriarOfertaUseCase
{
    private readonly ILoginUser _loginUser;
    private readonly IOfferRepository _Repository;
    public CriarOfertaUseCase(ILoginUser loginUser, IOfferRepository Repository)
    {
        _loginUser = loginUser;
        _Repository = Repository;
    }
    
    public int Execute(int ItemId, RequestCreatOfferJson request)
    {
        
        var user = _loginUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = ItemId,
            Price = request.Price,
            UserId = user.Id,
        };

       _Repository.Add(offer);

        return offer.Id;

    }
}