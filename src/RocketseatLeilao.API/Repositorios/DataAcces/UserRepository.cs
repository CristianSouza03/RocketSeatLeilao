using RocketseatLeilao.API.Contratos;
using RocketseatLeilao.API.Entities;

namespace RocketseatLeilao.API.Repositorios.DataAcces;

public class UserRepository : IUserRepository
{
    private readonly RocketseatLeilaoDbContext _dbContext;
    public UserRepository(RocketseatLeilaoDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email)
    {
       return _dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));



}
