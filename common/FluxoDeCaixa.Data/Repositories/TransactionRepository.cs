using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Data.Repositories;

public class TransactionRepository : BaseRepository<Transacao>
{
    public TransactionRepository(DbConnection dbConnection) : base(dbConnection)
    {

    }
}
