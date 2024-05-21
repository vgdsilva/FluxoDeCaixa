using Bumptech.Glide.Request;
using DataAccessObject.SQLite;
using FluxoDeCaixa.Domain.Entities;

namespace FluxoDeCaixa.Features.OperationCategory;

public static class CreateOperationCategory
{
   public static void Execute(Domain.Entities.OperationCategory entity)
    {
        using (Database database = Core.Configuration.Factory.GetDatabase())
        {
            try
            {
                database.SQL = "SELECT * FROM OPERATIONCATEGORY WHERE OPERATIONCATEGORYID = " + entity.OperationCategoryID;
                List<Domain.Entities.OperationCategory> itens = (database.QueryAsync<Domain.Entities.OperationCategory>()).Result;
                if (itens.Count > 0)
                {
                    database.SQL = @"UPDATE OPERATIONCATEGORY 
                                     SET DESCRIPTION = @DESCRIPTION, 
                                         COLORHEX = @COLORHEX, 
                                         FAICON = @FAICON 
                                     WHERE OPERATIONCATEGORYID = @OPERATIONCATEGORYID";
                }
                else
                {
                    database.SQL = @"INSERT INTO OPERATIONCATEGORIES (OPERATIONCATEGORYID, DESCRIPTION, COLORHEX, FAICON) 
                                    VALUES (@OPERATIONCATEGORYID, @DESCRIPTION, @COLORHEX, @FAICON)";
                }

                database.AddParameter("@OPERATIONCATEGORYID", entity.OperationCategoryID);
                database.AddParameter("@DESCRIPTION", entity.Description);
                database.AddParameter("@COLORHEX", entity.ColorHex);
                database.AddParameter("@FAICON", entity.FAIcon);
                

                database.Execute();
            }
            catch ( Exception ex )
            {

                throw;
            }
        }
    }

    public static bool Validate(Domain.Entities.OperationCategory entity)
    {
        if ( entity.OperationCategoryID.IsNewEntity() )
            entity.OperationCategoryID = Guid.NewGuid().ToString();

        return true;
    }
}
