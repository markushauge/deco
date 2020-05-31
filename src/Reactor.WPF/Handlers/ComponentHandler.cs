using Reactor.Binding;
using System;

using WPFView = System.Windows.UIElement;
using WPFContainer = System.Windows.Controls.ContentControl;

namespace Reactor.WPF.Handlers {
    public class ComponentHandler : IViewHandler<WPFView> {
        private readonly ViewHandlerRegistry _registry;
        private WPFContainer? _container;

        public ComponentHandler(ViewHandlerRegistry registry) {
            _registry = registry;
        }

        private void RenderComponent(Component component, WPFContainer container) {
            var virtualView = component.Render();
            
            if (virtualView != null) {
                container.Content = _registry.Render(virtualView);
            }
        }

        private void Bind(object target, Action action) {
            foreach (var binding in _registry.BindingRegistry[target]) {
                binding.Changed += action;
                
                if (binding is BindingObject bindingObject) {
                    Bind(binding, bindingObject.OnChanged);
                }
            }
        }

        public WPFView Render(IView view) {
            var component = (Component)view;
            component.OnMount();

            if (_container == null) {
                _container = new WPFContainer();
                Bind(component, () => RenderComponent(component, _container));
            }

            RenderComponent(component, _container);
            return _container;
        }
    }
}
