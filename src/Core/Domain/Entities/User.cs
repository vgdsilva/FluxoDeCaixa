using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FluxoDeCaixa.Mobile.Core.Domain.Entities;

public class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();

    public string Alias { get; set; } = string.Empty;

    public int MyProperty { get; set; }

    public List<Account> Wallet { get; set; } = new List<Account>();
}
