using System;

namespace Reactor.Binding {
    public abstract class BindingObject : IBinding {
        public event Action? Changed;

        public BindingObject() {
            foreach (var binding in BindingRegistry.Default[this]) {
                binding.Changed += () => Changed?.Invoke();
            }
        }
    }
}
