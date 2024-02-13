using RocketseatLeilao.API.Contratos;
using RocketseatLeilao.API.Entities;

namespace RocketseatLeilao.API.Serviços;

public class LoginUser : ILoginUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _repository;
    public LoginUser(IHttpContextAccessor httpContext, IUserRepository repository)
    {
        _httpContextAccessor = httpContext;
        _repository = repository;
    }
    public User User()
    {

        var token = TokenOnRequest();

        var email = FromBase64String(token);

        return _repository.GetUserByEmail(email);
    }

    private string TokenOnRequest()
    {
        var autenticacao = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();


        return autenticacao["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
