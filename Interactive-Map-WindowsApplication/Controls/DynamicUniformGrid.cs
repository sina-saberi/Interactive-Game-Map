using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Interactive_Map_WindowsApplication.Controls
{
    public class DynamicUniformGrid : UniformGrid
    {
        public double ItemWidth { get; set; } = 150; // The width of each item

        protected override Size MeasureOverride(Size availableSize)
        {
            // Calculate the number of columns based on the available width and item width
            double panelWidth = availableSize.Width;

            // Calculate the number of columns that fit within the available width
            int columns = (int)(panelWidth / ItemWidth);

            // Ensure that there is at least 1 column
            columns = Math.Max(1, columns);

            // Set the number of columns for the UniformGrid dynamically
            this.Columns = columns;

            // Call the base class MeasureOverride to calculate the size for children
            return base.MeasureOverride(availableSize);
        }
    }
}