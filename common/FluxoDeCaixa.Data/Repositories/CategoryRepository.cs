using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Data.Repositories;

public class CategoryRepository
{
    private readonly DbConnection _dbConnection;

    public CategoryRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Category> SaveAsync(Category entity)
    {
        await _dbConnection.Init();

        if ((await _dbConnection.Database.Table<Category>().Where(x => x.Id == entity.Id).FirstOrDefaultAsync()) == null)
        {
            await CreateAsync(entity);
        }
        else
        {
            await UpdateAsync(entity);
        }

        var category = await _dbConnection.Database
            .Table<Category>()
            .Where(c => c.Id == entity.Id)
            .FirstAsync();

        return category;
    }

    private async Task CreateAsync(Category entity)
    {
        _ = await _dbConnection.Database.InsertAsync(entity);
    }
    
    private async Task UpdateAsync(Category entity)
    {
        _ = await _dbConnection.Database.UpdateAsync(entity);
    }
}
