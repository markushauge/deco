using Reactor.Styling;

namespace Reactor.Views {
    public abstract class StackLayout : Container<IView> {
        public abstract Orientation Orientation { get; }
    }
}
