using FluxoDeCaixa.MAUI.Componentes;
using FluxoDeCaixa.MAUI.Utils.Classes;

namespace FluxoDeCaixa.MAUI.Core.Utils.Classes;

public static class Execute
{
    public static async Task Task(Action command, Func<Task> onErrorCommand = null, Func<Task> onSuccessCommand = null)
    {
		try
		{
            command();
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

    public static async Task TaskWithLoading(Action action)
    {
        string callID = LoadingScreen.GenerateCallId();
        await LoadingScreen.Instance.Start(callID);

        try
        {
            action();
        }
        catch (Exception ex)
        {
            await SnackBar.ShowError(ex.Message);
        }
        finally
        {
            await LoadingScreen.Instance.Stop(callID);
        }
    }
}
