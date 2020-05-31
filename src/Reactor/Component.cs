using System.Collections.Generic;

namespace Reactor {
    public abstract class Component : IView {
        public virtual IEnumerable<IBinding> Bindings { get; } = new IBinding[0];
        public abstract IView? Render();
        public virtual void OnMount() { }
        public virtual void OnUnmount() { }
    }
}
