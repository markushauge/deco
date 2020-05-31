using Reactor.Components;
using Reactor.Demo.Model;
using Reactor.Views;

namespace Reactor.Demo.Components {
    public class Todo : Component {
        private readonly int _id;

        public Todo(int id) {
            _id = id;
        }

        public override IView? Render() =>
            new Resource<int, TodoModel>(_id, TodoApi.GetTodo) {
                RenderData = data =>
                    new VStack {
                        new Text($"Id: {data.Id}"),
                        new Text($"Title: {data.Title}"),
                        new Text($"Completed: {data.Completed}")
                    }
            };
    }
}
