using Reactor.Views;
using Reactor.Styling;
using System;

using WPFStackLayout = System.Windows.Controls.StackPanel;
using WPFOrientation = System.Windows.Controls.Orientation;

namespace Reactor.WPF.Handlers {
    public class StackLayoutHandler : AbstractViewHandler<StackLayout, WPFStackLayout> {
        private readonly ViewHandlerRegistry _registry;

        public StackLayoutHandler(ViewHandlerRegistry registry) {
            _registry = registry;
        }

        protected override WPFStackLayout CreateView(StackLayout virtualView) => new WPFStackLayout();
        
        protected override void UpdateProperties(StackLayout? oldStack, StackLayout newStack, WPFStackLayout nativeStack) {
            nativeStack.CanVerticallyScroll = true;

            nativeStack.Orientation = newStack.Orientation switch {
                Orientation.Horizontal => WPFOrientation.Horizontal,
                Orientation.Vertical => WPFOrientation.Vertical,
                _ => throw new InvalidOperationException()
            };

            nativeStack.Children.Clear();

            foreach (var child in newStack.Children) {
                nativeStack.Children.Add(_registry.Render(child));
            }
        }
    }
}
