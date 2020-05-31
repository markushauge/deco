using System;

namespace Reactor.Binding {
    public abstract class BindingObject : Bindable, IBinding {
        public event Action? Changed;

        public BindingObject() {
            foreach (var binding in Bindings) {
                binding.Changed += () => Changed?.Invoke();
            }
        }
    }
}
