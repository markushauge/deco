using Reactor.Views;

using WPFText = System.Windows.Controls.TextBlock;

namespace Reactor.WPF.Handlers {
    public class TextHandler : AbstractViewHandler<Text, WPFText> {
        protected override WPFText CreateView(Text virtualView) => new WPFText();

        protected override void UpdateProperties(Text? oldText, Text newText, WPFText nativeText) {
            nativeText.Text = newText.Body;
        }
    }
}
