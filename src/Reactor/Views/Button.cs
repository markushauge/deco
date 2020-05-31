using System;

namespace Reactor.Views {
    public class Button : View {
        public string Body { get; }
        public Action OnClick { get; }

        public Button(string body, Action onClick) {
            Body = body;
            OnClick = onClick;
        }
    }
}
