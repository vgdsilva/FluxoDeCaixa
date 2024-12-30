namespace FluxoDeCaixa.MAUI.ViewModels;

public partial class BaseViewModels : ObservableObject
{

    public BaseViewModels()
    {
        
    }


    public virtual void Init() { }

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

    public virtual void End() { }

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
