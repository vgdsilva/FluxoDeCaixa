using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace FluxoDeCaixa.MAUI.Utils.Classes
{
    public class SnackBarBuilder
    {
        private Snackbar _snackbar;

        private Color _backgroundColor;
        private string _message;
        private Color _textColor;
        private string _actionButtonText;
        private Color _actionButtonTextColor;
        private Action _action;
        private TimeSpan _duration;

        public SnackBarBuilder() { }

        public SnackBarBuilder SetBackgroundColor(Color backgroundColor)
        {
            _backgroundColor = backgroundColor;
            return this;
        }

        public SnackBarBuilder SetMessage(string message)
        {
            _message = message;
            return this;
        }


        public SnackBarBuilder SetTextColor(Color textColor)
        {
            _textColor = textColor;
            return this;
        }

        public SnackBarBuilder SetActionButtonText(string actionButtonText)
        {
            _actionButtonText = actionButtonText;
            return this;
        }

        public SnackBarBuilder SetActionButtonTextColor(Color buttonTextColor)
        {
            _actionButtonTextColor = buttonTextColor;
            return this;
        }

        public SnackBarBuilder SetAction(Action action)
        {
            _action = action;
            return this;
        }

        public SnackBarBuilder SetDuration(TimeSpan time)
        {
            _duration = time;
            return this;
        }

        public ISnackbar Build()
        {
            return Snackbar.Make(
                message: _message,
                action: _action,
                actionButtonText: _actionButtonText,
                duration: _duration,
                visualOptions: new SnackbarOptions
                {
                    BackgroundColor = _backgroundColor,
                    TextColor = _textColor,
                    ActionButtonTextColor = _actionButtonTextColor,
                    CornerRadius = new CornerRadius(16)
                });
        }

        public async Task Show(CancellationToken token = default)
        {
            await Snackbar
            .Make(
                message: _message,
                action: _action,
                actionButtonText: _actionButtonText,
                duration: _duration,
                visualOptions: new SnackbarOptions
                {
                    BackgroundColor = _backgroundColor,
                    TextColor = _textColor,
                    ActionButtonTextColor = _actionButtonTextColor,
                    CornerRadius = new CornerRadius(16),
                }
            )
            .Show(token);
        }
    }
}
