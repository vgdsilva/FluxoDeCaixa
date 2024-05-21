using Bumptech.Glide.Request;
using DataAccessObject.SQLite;
using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Features.OperationCategory;

public static class CreateOperationCategory
{
   public static void Execute(Domain.Entities.OperationCategory entity)
    {
        Database database = Core.Configuration.Factory.GetDatabase();   
    }

    public static void Validate(Domain.Entities.OperationCategory entity)
    {
        if ( entity.OperationCategoryID.IsNewEntity() )
            entity.OperationCategoryID = Guid.NewGuid().ToString();
    }
}
