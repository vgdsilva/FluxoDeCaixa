using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Moeda : BaseEntity
{
    public string IDMoeda { get; set; } = EmpytID();
    public string Descricao { get; set; } = string.Empty;
}
