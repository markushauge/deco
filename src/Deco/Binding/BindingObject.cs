using System;

namespace Deco.Binding {
    public abstract class BindingObject : IBinding {
        public event Action? Changed;
        public void OnChanged() => Changed?.Invoke();
    }
}
