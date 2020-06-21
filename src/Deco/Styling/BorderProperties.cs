namespace Deco.Styling {
    public class BorderProperties {
        public static readonly BorderProperties Default = new BorderProperties();

        public float Width { get; set; } = 0;
        public float Radius { get; set; } = 0;
        public Color Color { get; set; } = Color.Black;
    }
}
