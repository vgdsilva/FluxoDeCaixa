using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FluxoDeCaixa.Mobile.Core.Domain.Entities;

public class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = string.Empty;

    
}
