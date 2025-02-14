using FluxoDeCaixa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Data.Repositories
{
    public class TransasaoRepository
    {
        // Lista estática para armazenar as transações
        public static List<Transacao> Transacoes { get; } = new List<Transacao>();
    }

    public class MockDataGenerator
    {
        private static Random random = new Random();

        public static void GerarTransacoes(int quantidade, DateTime? dataReferencia = null)
        {
            for (int i = 0; i < quantidade; i++)
            {
                string descricao = $"Transacao {Guid.NewGuid()}";
                decimal valor = (decimal)(random.NextDouble() * 1000); // Valor aleatório entre 0 e 1000
                DateTime data = dataReferencia.HasValue ? GerarDataNoMesmoMesAno(dataReferencia.Value) : GerarDataAleatoria();
                int tipoTransacao = random.Next(0, 2); // 0 ou 1

                // Adiciona a transação à lista estática
                TransasaoRepository.Transacoes.Add(new Transacao(descricao, valor, data, tipoTransacao));
            }
        }

        private static DateTime GerarDataNoMesmoMesAno(DateTime dataReferencia)
        {
            // Gera um dia aleatório dentro do mesmo mês e ano da data de referência
            int ano = dataReferencia.Year;
            int mes = dataReferencia.Month;
            int diasNoMes = DateTime.DaysInMonth(ano, mes); // Número de dias no mês

            int diaAleatorio = random.Next(1, diasNoMes + 1); // Dia aleatório entre 1 e o último dia do mês

            return new DateTime(ano, mes, diaAleatorio);
        }

        private static DateTime GerarDataAleatoria()
        {
            // Gera uma data aleatória dentro de um intervalo de 1 ano antes e 1 ano depois da data atual
            DateTime start = DateTime.Today.AddYears(-1);
            DateTime end = DateTime.Today.AddYears(1);

            int totalDias = (end - start).Days;
            return start.AddDays(random.Next(totalDias));
        }
    }
}
