using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.MAUI.Core.Utils.Classes
{
    public static class Execute
    {
        public static async Task Task(Func<Task> command, Func<Task> onErrorCommand = null, Func<Task> onSuccessCommand = null)
        {
			try
			{
                await command();
			}
			catch (Exception ex)
			{
                if (onErrorCommand != null)
                    await onErrorCommand();
			}
            finally
            {
                if (onSuccessCommand != null)
                    await onSuccessCommand();
            }
        }
    }
}
