using Reactor.Views;

using WPFTextInput = System.Windows.Controls.TextBox;

namespace Reactor.WPF.Handlers {
    public class TextInputHandler : AbstractViewHandler<TextInput, WPFTextInput> {
        protected override WPFTextInput CreateView(TextInput virtualView) => new WPFTextInput();

        protected override void UpdateProperties(TextInput? oldTextInput, TextInput newTextInput, WPFTextInput nativeTextInput) {
            nativeTextInput.Text = newTextInput.State!.Value;
            nativeTextInput.TextChanged += (o, e) => newTextInput.State.Value = nativeTextInput.Text;
        }
    }
}
