namespace Deco.Extensions {
    public static class NumberExtensions {
        public static Number Px(this int value) => new Number(value, Unit.Pixel);
        public static Number Px(this float value) => new Number(value, Unit.Pixel);
        public static Number Fr(this int value) => new Number(value, Unit.Fractional);
        public static Number Fr(this float value) => new Number(value, Unit.Fractional);
    }
}
