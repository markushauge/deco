using Deco.Views;

namespace Deco.Demo.Components {
    public class Pagination : Component {
        private readonly IState<int> _page;

        public Pagination(IState<int> page) {
            _page = page;
        }

        public override IView Render() =>
            new VStack {
                new HStack {
                    new Button("Previous", () => _page.Value--),
                    new Button("Next", () => _page.Value++)
                }
            };
    }
}
