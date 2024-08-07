namespace Domain.Entities;

public class Categoria : BaseEntity
{
    public string IDCategoria { get; set; } = EmpytID();
    public string Descricao { get; set; } = string.Empty;

}
