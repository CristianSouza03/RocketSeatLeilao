using RocketseatLeilao.API.Entities;

namespace RocketseatLeilao.API.Contratos;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);

}
