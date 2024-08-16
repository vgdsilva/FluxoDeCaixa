using FluxoDeCaixa.Data.Geral;

namespace FluxoDeCaixa.Data.Repository;

public class FluxodecaixaRepository : AbstractRepository<Fluxodecaixa>
{

    public bool ExistsFluxoDeCaixa()
    {
        using (SQLQuery sql = MobileContext.Instance.AssignNewInstanceSQLQuery())
        {
            return sql.QueryFirstOrDefault<Fluxodecaixa>("SELECT * FROM FLUXODECAIXA") != null;
        }
    }

}
