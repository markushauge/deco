using Deco.Views;

using WPFButton = System.Windows.Controls.Button;

namespace Deco.WPF.Handlers {
    public class ButtonHandler : AbstractViewHandler<Button, WPFButton> {
        protected override WPFButton CreateView(Button virtualView) => new WPFButton();
        
        protected override void UpdateProperties(Button? oldButton, Button newButton, WPFButton nativeButton) {
            nativeButton.Content = newButton.Body;
            nativeButton.Click += (o, e) => newButton.OnClick?.Invoke();
        }
    }
}
