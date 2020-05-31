using Deco.Views;

namespace Deco.Views {
    public class ScrollView : View {
        public IView Body { get; }

        public ScrollView(IView body) {
            Body = body;
        }
    }
}
