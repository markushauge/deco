using Reactor.Views;

namespace Reactor.Views {
    public class ScrollView : View {
        public IView Body { get; }

        public ScrollView(IView body) {
            Body = body;
        }
    }
}
