using Deco.Views;
using System;
using System.Windows.Controls;

using WPFGridLayout = System.Windows.Controls.Grid;

namespace Deco.WPF.Handlers {
    public class GridLayoutHandler : AbstractViewHandler<GridLayout, WPFGridLayout> {
        private readonly ViewHandlerRegistry _registry;

        public GridLayoutHandler(ViewHandlerRegistry registry) {
            _registry = registry;
        }

        private GridLayout.Area GetArea(string? area, GridLayout grid) {
            if (area == null || grid.Areas == null || !grid.Areas.ContainsKey(area)) {
                return GridLayout.Area.Default;
            }

            return grid.Areas[area];
        }

        protected override WPFGridLayout CreateView(GridLayout virtualView) => new WPFGridLayout();
        
        protected override void UpdateProperties(GridLayout? oldGrid, GridLayout newGrid, WPFGridLayout nativeGrid) {
            nativeGrid.ColumnDefinitions.Clear();

            foreach (var column in newGrid.Columns) {
                nativeGrid.ColumnDefinitions.Add(
                    new ColumnDefinition { Width = column.ToGridLength() }
                );
            }

            nativeGrid.RowDefinitions.Clear();

            foreach (var row in newGrid.Rows) {
                nativeGrid.RowDefinitions.Add(
                    new RowDefinition { Height = row.ToGridLength() }
                );
            }

            nativeGrid.Children.Clear();

            foreach (var child in newGrid.Children) {
                if (child.Body == null) {
                    continue;
                }
                
                var body = _registry.Render(child.Body);
                nativeGrid.Children.Add(body);
                var area = GetArea(child.Area, newGrid);

                var (column, columnSpan) = area.Column.GetOffsetAndLength(newGrid.Columns.Count);
                WPFGridLayout.SetColumn(body, column);
                WPFGridLayout.SetColumnSpan(body, Math.Max(columnSpan, 1));

                var (row, rowSpan) = area.Row.GetOffsetAndLength(newGrid.Rows.Count);
                WPFGridLayout.SetRow(body, row);
                WPFGridLayout.SetRowSpan(body, Math.Max(rowSpan, 1));
            }
        }
    }
}
