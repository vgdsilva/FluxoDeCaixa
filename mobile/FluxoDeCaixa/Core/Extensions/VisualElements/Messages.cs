using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDeCaixa.Mobile.Core.Extensions.VisualElements;
public class Messages
{
    public static async Task DiplayToastAsync(string message, ToastDuration duration = ToastDuration.Long) =>
        await Toast.Make(message, duration).Show();

    public static async Task SnackBarAsync(string message, string actionButtonText = null, Action action = null, TimeSpan? duration = null)
    {

    }
}
