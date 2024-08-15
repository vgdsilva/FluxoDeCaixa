using FluxoDeCaixa.Data.Geral;

namespace FluxoDeCaixa.Data.Repository;

public class FluxodecaixaRepository : AbstractRepository<Fluxodecaixa>
{
    public static FluxodecaixaRepository Instance => Instance ?? new FluxodecaixaRepository();


    public FluxodecaixaRepository()
    {
        
    }

    public bool ExistsFluxoDeCaixa()
    {

        throw new Exception("TESTEEEEEEEEEEEE");

        using (SQLQuery sql = MobileContext.Instance.AssignNewInstanceSQLQuery())
        {
            return sql.QueryFirstOrDefault<Fluxodecaixa>("SELECT * FROM FLUXODECAIXA") != null;
        }
    }

}
