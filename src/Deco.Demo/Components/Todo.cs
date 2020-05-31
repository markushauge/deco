using Deco.Demo.Model;
using Deco.Views;
using Deco.WPF.Components;

namespace Deco.Demo.Components {
    public class Todo : Component {
        private readonly int _id;

        public Todo(int id) {
            _id = id;
        }

        public override IView? Render() =>
            new ResourceView<int, TodoModel>(_id, TodoApi.GetTodo) {
                RenderData = data =>
                    new VStack {
                        new Text($"Id: {data.Id}"),
                        new Text($"Title: {data.Title}"),
                        new Text($"Completed: {data.Completed}")
                    }
            };
    }
}
