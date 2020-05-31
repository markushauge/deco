using System;
using System.Collections.Generic;

namespace Reactor.Views {
    public class GridLayout : Container<GridLayout.Item> {
        public class Item {
            public Range Column { get; set; } = Range.All;
            public Range Row { get; set; } = Range.All;
            public IView? Body { get; set; } = null;
        }

        public IReadOnlyList<Number>? Columns { get; set; }
        public IReadOnlyList<Number>? Rows { get; set; }
    }
}
