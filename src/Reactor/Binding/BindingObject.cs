using System;

namespace Reactor.Binding {
    public abstract class BindingObject : IBinding {
        protected abstract IBinding[] Bindings { get; }
        public event Action? Changed;

        public BindingObject() {
            foreach (var binding in Bindings) {
                binding.Changed += () => Changed?.Invoke();
            }
        }
    }
}
