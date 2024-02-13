using Bogus;
using FluentAssertions;
using Moq;
using RocketseatLeilao.API.Comunicação.Requests;
using RocketseatLeilao.API.Contratos;
using RocketseatLeilao.API.Entities;
using RocketseatLeilao.API.Enums;
using RocketseatLeilao.API.Serviços;
using RocketseatLeilao.API.UseCase.Leiloes.GetCurrent;
using RocketseatLeilao.API.UseCase.Ofertas.CriarOferta;
using Xunit;

namespace UseCase.Test.Leilao.GetCurrent;
public class GetCurrentLeilaoUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        //ARRANGE
        var request = new Faker<RequestCreatOfferJson>()
           .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700)).Generate();
           

        var offerrepository = new Mock<IOfferRepository>();
        var user = new Mock<ILoginUser>();
        user.Setup(i => i.User()).Returns(new User());
        
        var useCase = new CriarOfertaUseCase(user.Object, offerrepository.Object);

        //ACT
        var act = () => useCase.Execute(itemId, request);

        //ASSERT
        act.Should().NotThrow();
    }
}
