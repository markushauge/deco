using System;

namespace Reactor.Views {
    public class Button : View {
        public string Body { get; set; } = "";
        public Action? OnClick { get; set; } = null;
    }
}
