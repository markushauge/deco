using Reactor.WPF;
using System.Reflection;

namespace Reactor.Demo.WPF {
    public class ComponentHost : ViewHost {
        protected override Assembly Assembly => Assembly.GetExecutingAssembly();
        protected override string Namespace => "Reactor.Demo.Components";
    }
}
