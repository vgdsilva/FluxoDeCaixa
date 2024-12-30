using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Infrastructure.SQLite.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(FluxoDeCaixaDbContext context) : base(context)
    {

    }
}
