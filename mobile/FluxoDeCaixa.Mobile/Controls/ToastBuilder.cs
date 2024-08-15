using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Controls;

public class ToastBuilder
{
    private ToastPopup? _Toast = null;
    private string _Message = string.Empty;
    private bool _ShowLoadingAnimation = true;
    private bool _ShowIcon = false;
    private bool _ModalBehavior = false;
    private string _Icon = string.Empty;
    private Color _BackgroundColor = Color.FromHex("#1F2937");

    public ToastBuilder()
    {
        
    }

    public ToastBuilder SetMessage(string message)
    {
        _Message = message;
        return this;
    }

    public ToastBuilder SetModalBehavior(bool modalBehavior)
    {
        _ModalBehavior = modalBehavior;
        return this;
    }

    public ToastBuilder SetBackgroundColor(Color backgroundColor)
    {
        _BackgroundColor = backgroundColor;
        return this;
    }

    public ToastPopup Build()
    {
        _Toast = new ToastPopup(_Message, _ModalBehavior);
        _Toast.SetBackgroundColor(_BackgroundColor);
        //_Toast.ShowIcon(_ShowIcon);
        //_Toast.SetIcon(_Icon);

        return _Toast;
    }
}
