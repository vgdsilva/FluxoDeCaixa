using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.MAUI.Views.Pages.Base
{
    public class BaseModels : ObservableValidator
    {
        //public static IMapper mapper = MapperService.CreateMapper();

        public bool ValidateForm()
        {
            ValidateAllProperties();
            var errors = GetErrors();
            return errors.Count() > 0;
        }

        //public TDestination Map<TDestination>(object source)
        //{
        //    return mapper.Map<TDestination>(source);
        //}
    }
}
