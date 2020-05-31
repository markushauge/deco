using Reactor.Views;

namespace Reactor.Demo.Components {
    public class Pagination : Component {
        private readonly IState<int> _page;

        public Pagination(IState<int> page) {
            _page = page;
        }

        public override IView Render() =>
            new VStack {
                new HStack {
                    new Button {
                        Body = "Previous",
                        OnClick = () => _page.Value--
                    },
                    new Button {
                        Body = "Next",
                        OnClick = () => _page.Value++
                    }
                }
            };
    }
}
