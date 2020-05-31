using System;

namespace Reactor.Binding {
    public abstract class BindingObject : IBinding {
        public event Action? Changed;
        public void OnChanged() => Changed?.Invoke();
    }
}
