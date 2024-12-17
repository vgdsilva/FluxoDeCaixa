using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Infrastructure.Persistence
{
    public class MigrationService
    {
        private readonly DbContext _dbContext;

        public MigrationService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AtualizarBancoDeDados()
        {
            
        }
    }
}
