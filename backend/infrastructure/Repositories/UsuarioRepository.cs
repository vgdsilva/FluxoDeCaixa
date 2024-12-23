using FluxoDeCaixa.Domain.Entities;
using FluxoDeCaixa.Domain.Interfaces;
using FluxoDeCaixa.Infrastructure.Context;
using FluxoDeCaixa.Infrastructure.Controller;

namespace FluxoDeCaixa.Infrastructure.Repositories;

public class UsuarioRepository
{
    public async Task<Usuario> VerificaSeUsuarioExisteAsync(string email)
    {
        using (SQLQuery query = Contexto.Instance.SQLQueryNewInstance())
        {
            query.SQL = "";


            return new Usuario();
        }
    }
}
