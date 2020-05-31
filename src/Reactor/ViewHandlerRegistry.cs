using System;
using System.Collections.Generic;

namespace Reactor {
    public abstract class ViewHandlerRegistry<TViewHandler, TNativeView>
        where TViewHandler : IViewHandler<TNativeView>
        where TNativeView : class
    {
        private readonly IDictionary<Type, Func<TViewHandler>> _registry = new Dictionary<Type, Func<TViewHandler>>();

        public Func<TViewHandler> this[Type key] {
            get => _registry[key];
            set => _registry[key] = value;
        }

        public TNativeView Render(IView view) =>
            CreateViewHandler(view).Render(view);

        public TViewHandler CreateViewHandler(IView view) {
            foreach (var type in view.GetType().GetTypes()) {
                if (_registry.ContainsKey(type)) {
                    return _registry[type]();
                }
            }

            throw new Exception($"{view.GetType()} is not supported by this renderer");
        }
    }
}
