namespace Deco.Styling {
    public readonly partial struct Color {
        public readonly byte R;
        public readonly byte G;
        public readonly byte B;
        public readonly byte A;

        public Color(byte r, byte g, byte b) : this(r, g, b, 255) { }

        public Color(byte r, byte g, byte b, byte a) {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }

    public readonly partial struct Color {
        public static readonly Color Transparent = new Color(0, 0, 0, 0);
        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color White = new Color(255, 255, 255);
    }
}
