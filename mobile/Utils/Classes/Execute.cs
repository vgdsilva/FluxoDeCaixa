using FluxoDeCaixa.MAUI.Utils.Classes;

namespace FluxoDeCaixa.MAUI.Core.Utils.Classes;

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
             await SnackBar.ShowError(ex.Message);
            
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
