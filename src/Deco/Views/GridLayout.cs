using System;
using System.Collections.Generic;

namespace Deco.Views {
    public class GridLayout : Container<GridLayout.Item> {
        public class Item {
            public string? Area { get; set; } = null;
            public IView? Body { get; set; } = null;
        }

        public class Area {
            public static Area Default = new Area();

            public Range Column { get; set; } = Range.All;
            public Range Row { get; set; } = Range.All;
        }

        public IReadOnlyList<Number> Columns { get; set; } = new Number[0];
        public IReadOnlyList<Number> Rows { get; set; } = new Number[0];
        public IReadOnlyDictionary<string, Area>? Areas { get; set; }
    }
}
