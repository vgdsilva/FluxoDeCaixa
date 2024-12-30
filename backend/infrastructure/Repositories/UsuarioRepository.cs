using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Infrastructure.Configuraction;
using FluxoDeCaixa.Infrastructure.Controller;

namespace FluxoDeCaixa.Infrastructure.Repositories;

public class UsuarioRepository
{
    public DataRow? VerificaSeUsuarioExiste(string email, string password)
    {
        using (Database db = ConnectionFactory.GetDatabase())
        {
            DataRow? item = db.Tables["Users"].FirstOrDefault(item => item["Email"].Equals(email) && item["Password"].Equals(password));
            return item;
        }
    }
}
