using Deco.Styling;
using System;
using System.Windows;

using WPFOrientation = System.Windows.Controls.Orientation;

namespace Deco.WPF {
    public static class WPFExtensions {
        public static WPFOrientation ToOrientation(this Orientation orientation) =>
            orientation switch {
                Orientation.Vertical => WPFOrientation.Vertical,
                Orientation.Horizontal => WPFOrientation.Horizontal,
                _ => throw new InvalidOperationException()
            };
        
        public static GridLength ToGridLength(this Number number) =>
            number switch {
                (var value, Unit.Pixel) => new GridLength(value, GridUnitType.Pixel),
                (var value, Unit.Fractional) => new GridLength(value, GridUnitType.Star),
                (_, Unit.Auto) => new GridLength(0, GridUnitType.Auto),
                _ => throw new InvalidOperationException()
            };
    }
}
