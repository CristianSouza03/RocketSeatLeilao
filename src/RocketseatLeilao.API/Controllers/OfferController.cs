using Microsoft.AspNetCore.Mvc;
using RocketseatLeilao.API.Comunicação.Requests;
using RocketseatLeilao.API.Filtros;
using RocketseatLeilao.API.UseCase.Ofertas.CriarOferta;

namespace RocketseatLeilao.API.Controllers;

[ServiceFilter(typeof(AutorizacaoUserAtributo))]
public class OfferController : RocketseatLeilaoBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreatOffer(
        [FromRoute]int itemId, 
        [FromBody] RequestCreatOfferJson request, 
        [FromServices] CriarOfertaUseCase useCase)
    {
       var id = useCase.Execute(itemId, request);

        return Created(string.Empty, id);
    }
}
