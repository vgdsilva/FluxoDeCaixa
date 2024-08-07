namespace Domain.Entities;

public class Fluxodecaixa : BaseEntity
{
    public string IDFluxodecaixa { get; set; } = EmpytID();
    public string Descricao { get; set; } = string.Empty;
    public string IDMoeda { get; set; } = EmpytID();
    public int NumeroCasasDecimais { get; set; } = 2;

    public virtual Moeda MoedaEntidade { get; set; }
}
