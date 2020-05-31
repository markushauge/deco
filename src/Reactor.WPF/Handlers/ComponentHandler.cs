using WPFView = System.Windows.UIElement;
using WPFContainer = System.Windows.Controls.Grid;

namespace Reactor.WPF.Handlers {
    public class ComponentHandler : IViewHandler<WPFView> {
        private readonly ViewHandlerRegistry _registry;
        private IView? _virtualView;
        private WPFContainer? _container;

        public ComponentHandler(ViewHandlerRegistry registry) {
            _registry = registry;
        }

        private void RenderComponent(Component component, WPFContainer container) {
            if (_virtualView != null) {
                container.Children.RemoveAt(0);
            }

            var virtualView = component.Render();
            
            if (virtualView != null) {
                container.Children.Add(_registry.Render(virtualView));
            }

            _virtualView = virtualView;
        }

        public WPFView Render(IView view) {
            var component = (Component)view;
            component.OnMount();

            if (_container == null) {
                _container = new WPFContainer();

                foreach (var binding in component.Bindings) {
                    binding.Changed += () => RenderComponent(component, _container);
                }
            }

            RenderComponent(component, _container);
            return _container;
        }
    }
}
