using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Core.Extensions.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class EnumDescription : Attribute
{
    public string Description { get; }
    public string Tag { get; }

    public EnumDescription(string tagTraducao)
    {
        Description = tagTraducao;
        Tag = tagTraducao;
    }
}
