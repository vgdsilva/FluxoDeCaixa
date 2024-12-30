using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Domain.Interfaces.Builders
{
    public interface IBuilder<TEntity> where TEntity : class
    {

        TEntity Build();
    }
}
