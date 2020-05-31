using Reactor.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using WPFGridLayout = System.Windows.Controls.Grid;

namespace Reactor.WPF.Handlers {
    public class GridLayoutHandler : AbstractViewHandler<GridLayout, WPFGridLayout> {
        private readonly ViewHandlerRegistry _registry;

        public GridLayoutHandler(ViewHandlerRegistry registry) {
            _registry = registry;
        }

        private GridLength ToGridLength(Number? number) =>
            number switch {
                (var value, Unit.Pixel) => new GridLength(value, GridUnitType.Pixel),
                (var value, Unit.Fractional) => new GridLength(value, GridUnitType.Star),
                _ => new GridLength(0, GridUnitType.Auto)
            };

        private IReadOnlyList<GridLength> ToGridLengths(IEnumerable<Number?>? numbers) {
            if (numbers == null) {
                return new GridLength[0];
            }

            return numbers.Select(ToGridLength).ToArray();
        }

        protected override WPFGridLayout CreateView(GridLayout virtualView) => new WPFGridLayout();
        
        protected override void UpdateProperties(GridLayout? oldGrid, GridLayout newGrid, WPFGridLayout nativeGrid) {
            var columns = ToGridLengths(newGrid.Columns);
            var rows = ToGridLengths(newGrid.Rows);

            nativeGrid.ColumnDefinitions.Clear();

            foreach (var column in columns) {
                nativeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = column });
            }

            nativeGrid.RowDefinitions.Clear();

            foreach (var row in rows) {
                nativeGrid.RowDefinitions.Add(new RowDefinition { Height = row });
            }

            nativeGrid.Children.Clear();

            foreach (var child in newGrid.Children) {
                if (child.Body == null) {
                    continue;
                }

                var body = _registry.Render(child.Body);
                nativeGrid.Children.Add(body);

                var (column, columnSpan) = child.Column.GetOffsetAndLength(columns.Count);
                WPFGridLayout.SetColumn(body, column);
                WPFGridLayout.SetColumnSpan(body, Math.Max(columnSpan, 1));

                var (row, rowSpan) = child.Row.GetOffsetAndLength(rows.Count);
                WPFGridLayout.SetRow(body, row);
                WPFGridLayout.SetRowSpan(body, Math.Max(rowSpan, 1));
            }
        }
    }
}
