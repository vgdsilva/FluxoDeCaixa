namespace FluxoDeCaixa.MAUI.ViewModels;

public abstract partial class BaseViewModels : ObservableObject
{

    public BaseViewModels()
    {
        
    }


    public abstract void Init();

    public void OnAppearing()
    {
		try
		{
            Init();
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{

		}
    }

    public abstract void End();

	public void OnDisappearing()
	{
        try
        {
            End();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }

}
