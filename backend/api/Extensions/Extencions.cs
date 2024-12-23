using Microsoft.AspNetCore.Mvc;

namespace FluxoDeCaixa.API
{
    public static class Extencions
    {

        public static string GetLocalUrl(this IUrlHelper urlHelper, string localUrl)
        {
            if (!urlHelper.IsLocalUrl(localUrl))
            {
                return urlHelper.Page("/Index");
            }

            return localUrl;
        }
    }
}
