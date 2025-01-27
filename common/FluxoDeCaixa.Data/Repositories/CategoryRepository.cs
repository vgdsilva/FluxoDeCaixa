using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Data.Repositories;

public class CategoryRepository : BaseRepository<Categoria>
{

    public CategoryRepository(DbConnection dbConnection) : base(dbConnection)
    {
        
    }

    public async Task<Categoria> SaveAsync(Categoria entity)
    {
        await _dbConnection.Init();

        if ((await _dbConnection.Database.Table<Categoria>().Where(x => x.Id == entity.Id).FirstOrDefaultAsync()) == null)
        {
            await CreateAsync(entity);
        }
        else
        {
            await UpdateAsync(entity);
        }

        var category = await _dbConnection.Database
            .Table<Categoria>()
            .Where(c => c.Id == entity.Id)
            .FirstAsync();

        return category;
    }

    private async Task CreateAsync(Categoria entity)
    {
        entity.Id = Guid.NewGuid();
        _ = await _dbConnection.Database.InsertAsync(entity);
    }
    
    private async Task UpdateAsync(Categoria entity)
    {
        _ = await _dbConnection.Database.UpdateAsync(entity);
    }


}
