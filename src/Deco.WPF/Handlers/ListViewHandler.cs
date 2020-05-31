using Deco.Views;
using System.Collections.Generic;
using System.Linq;
using WPFListView = System.Windows.Controls.ListView;

namespace Deco.WPF.Handlers {
    public class ListViewHandler : AbstractViewHandler<ListView, WPFListView> {
        private readonly ViewHandlerRegistry _registry;

        public ListViewHandler(ViewHandlerRegistry registry) {
            _registry = registry;
        }

        protected override WPFListView CreateView(ListView virtualView) => new WPFListView();
        
        protected override void UpdateProperties(ListView? oldListView, ListView newListView, WPFListView nativeListView) {
            nativeListView.ItemsSource = newListView.Children.Select(_registry.Render);
        }
    }
}
