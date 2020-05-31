using Reactor.Binding;

namespace Reactor {
    public abstract class Component : Bindable, IView {
        public abstract IView? Render();
        public virtual void OnMount() { }
        public virtual void OnUnmount() { }
    }
}
