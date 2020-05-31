namespace Deco.Views {
    public class TextInput : View {
        public IState<string> State { get; }

        public TextInput(IState<string> state) {
            State = state;
        }
    }
}
