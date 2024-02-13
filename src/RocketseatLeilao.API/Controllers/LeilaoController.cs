using Microsoft.AspNetCore.Mvc;
using RocketseatLeilao.API.Entities;
using RocketseatLeilao.API.UseCase.Leiloes.GetCurrent;

namespace RocketseatLeilao.API.Controllers;

public class LeilaoController : RocketseatLeilaoBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentLeilao([FromServices] GetCurrentLeilaoUseCase useCase)
    {
        
        var result = useCase.Execute();

        if (result is null)
            return NoContent();

        return Ok(result);
    }
}
