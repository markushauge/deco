using System;

namespace Reactor {
    public readonly struct Number {
        public static Number Auto => new Number(0, Unit.Auto);

        public readonly float Value;
        public readonly Unit Unit;

        public Number(float value, Unit unit) {
            Value = value;
            Unit = unit;
        }
        
        public void Deconstruct(out float value, out Unit unit) {
            value = Value;
            unit = Unit;
        }

        public override string ToString() =>
            Unit switch {
                Unit.Pixel => $"{Value}px",
                Unit.Fractional => $"{Value}fr",
                _ => throw new InvalidOperationException()
            };
    }
}
