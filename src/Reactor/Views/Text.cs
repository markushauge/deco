namespace Reactor.Views {
    public class Text : View {
        public string Body { get; }

        public Text(string body) {
            Body = body;
        }
    }
}
