using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Core.Services.AutoMapper
{
    public static class AutoMapperService
    {
        private static IMapper iMapper = null;

        public static IMapper CreateMapper()
        {
            if (iMapper != null)
                return iMapper;


            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {

            });

            iMapper = mapperConfiguration.CreateMapper();
            return iMapper;
        }
    }
}
