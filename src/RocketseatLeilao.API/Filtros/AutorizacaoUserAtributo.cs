using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketseatLeilao.API.Contratos;

namespace RocketseatLeilao.API.Filtros;

public class AutorizacaoUserAtributo : AuthorizeAttribute, IAuthorizationFilter
{
    private IUserRepository _userRepository;

    public AutorizacaoUserAtributo(IUserRepository userRepository) => _userRepository = userRepository;
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);

            var email = FromBase64String(token);

            var exits = _userRepository.ExistUserWithEmail(email);

            if (exits == false)
            {
                context.Result = new UnauthorizedObjectResult("E-mail not valid");
            }
        }

        catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var autenticacao = context.Request.Headers.Authorization.ToString();

        if(string.IsNullOrEmpty(autenticacao))
        {
            throw new Exception("Token is missing valid");
        }

        return autenticacao["Bearer ".Length..];
    }

    private string FromBase64String(string base64) 
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }

}
