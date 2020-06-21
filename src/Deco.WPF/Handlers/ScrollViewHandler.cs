using Deco.Views;
using System.Windows.Controls;

using WPFScrollView = System.Windows.Controls.ScrollViewer;

namespace Deco.WPF.Handlers {
    public class ScrollViewHandler : AbstractViewHandler<ScrollView, WPFScrollView> {
        private readonly ViewHandlerRegistry _registry;

        public ScrollViewHandler(ViewHandlerRegistry registry) {
            _registry = registry;
        }

        protected override WPFScrollView CreateView(ScrollView virtualView) => new WPFScrollView();

        protected override void UpdateProperties(ScrollView? oldScrollView, ScrollView newScrollView, WPFScrollView nativeScrollView) {
            nativeScrollView.Content = _registry.Render(newScrollView.Body);
            nativeScrollView.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            nativeScrollView.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
        }
    }
}
