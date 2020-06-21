using Deco.Styling;

namespace Deco.Views {
    public abstract class StackLayout : Container<IView> {
        public abstract Orientation Orientation { get; }
    }
}
