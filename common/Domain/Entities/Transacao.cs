namespace Domain.Entities;

public class Transacao : BaseEntity
{
    public string IDTransacao { get; set; } = EmpytID();

    public string Descricao { get; set; } = string.Empty;

    public int Tipo { get; set; } = 0;

    public string IDCategoria { get; set; } = EmpytID();

    public string IDFluxodecaixa { get; set; } = EmpytID();

    public decimal Valor { get; set; } = 0;

    public DateTime Data { get; set; } = DateTime.Now;


    public virtual Categoria CategoriaEntidade { get; set; }

    public virtual Fluxodecaixa FluxodecaixaEntidade { get; set; }
}
