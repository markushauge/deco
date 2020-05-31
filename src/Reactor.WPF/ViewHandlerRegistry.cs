using Reactor.Views;
using Reactor.WPF.Handlers;

using WPFView = System.Windows.UIElement;
using WPFContainer = System.Windows.Controls.Panel;

namespace Reactor.WPF {
    public class ViewHandlerRegistry : ViewHandlerRegistry<IViewHandler<WPFView>, WPFView> {
        public static readonly ViewHandlerRegistry Default = new ViewHandlerRegistry();

        public ViewHandlerRegistry() {
            this[typeof(Component)] = () => new ComponentHandler(this);

            // Layouts
            this[typeof(StackLayout)] = () => new StackLayoutHandler(this);
            this[typeof(GridLayout)] = () => new GridLayoutHandler(this);

            // Controls
            this[typeof(Text)] = () => new TextHandler();
            this[typeof(TextInput)] = () => new TextInputHandler();
            this[typeof(Button)] = () => new ButtonHandler();
            this[typeof(ScrollView)] = () => new ScrollViewHandler(this);
        }

        public void Render(IView virtualView, WPFContainer container) {
            var viewHandler = CreateViewHandler(virtualView);
            var nativeView = viewHandler.Render(virtualView);
            container.Children.Add(nativeView);
        }
    }
}
