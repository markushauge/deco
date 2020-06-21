using Deco.WPF;
using System.Reflection;

namespace Deco.Demo.WPF {
    public class ComponentHost : ViewHost {
        protected override Assembly Assembly => Assembly.GetExecutingAssembly();
        protected override string Namespace => "Deco.Demo.Components";
    }
}
