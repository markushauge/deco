using System.Collections.Generic;

namespace Reactor.Binding {
    public abstract class Bindable {
        public IEnumerable<IBinding> Bindings =>
            BindingRegistry.Default.GetBindings(this);
    }
}
