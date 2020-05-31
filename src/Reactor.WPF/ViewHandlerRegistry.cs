using Reactor.Binding;
using Reactor.Views;
using Reactor.WPF.Handlers;

using WPFView = System.Windows.UIElement;

namespace Reactor.WPF {
    public class ViewHandlerRegistry : ViewHandlerRegistry<WPFView> {
        public static readonly ViewHandlerRegistry Default = new ViewHandlerRegistry();

        public BindingRegistry BindingRegistry = new BindingRegistry();

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
    }
}
