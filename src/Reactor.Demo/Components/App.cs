using Reactor.Binding;
using Reactor.Extensions;
using Reactor.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reactor.Demo.Components {
    public class App : Component {
        private readonly State<int> _page = 1;

        private IView RenderTodos() =>
            new ScrollView(
                new VStack {
                    Children = Enumerable
                        .Range(1, Math.Max(_page.Value, 1))
                        .Select(id => new Todo(id))
                        .ToArray()
                }
            );

        public override IView Render() =>
            new GridLayout {
                Rows = new[] { Number.Auto, 1.Fr() },
                Areas = new Dictionary<string, GridLayout.Area> {
                    ["header"] = new GridLayout.Area {
                        Row = 0..1
                    },
                    ["content"] = new GridLayout.Area {
                        Row = 1..2
                    }
                },
                Children = new GridLayout.Item[] {
                    new GridLayout.Item {
                        Area = "header",
                        Body = new Pagination(_page)
                    },
                    new GridLayout.Item {
                        Area = "content",
                        Body = RenderTodos()
                    }
                }
            };
    }
}
