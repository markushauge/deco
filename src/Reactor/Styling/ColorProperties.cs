namespace Reactor.Styling {
    public class ColorProperties {
        public static readonly ColorProperties Default = new ColorProperties();

        public Color Text { get; set; } = Color.Black;
        public Color Background { get; set; } = Color.Transparent;
    }
}
