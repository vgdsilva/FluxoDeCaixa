using FluxoDeCaixa.Mobile.Core.Domain.Entities;

namespace FluxoDeCaixa.Mobile.Core.Data; 

public class Database
{

    public User CurrentUser { get; set; } = new User();

    public List<Account> Accounts { get; set; } = new List<Account>();

    public List<Transaction> Transactions { get; set; } = new List<Transaction>();


    
}
