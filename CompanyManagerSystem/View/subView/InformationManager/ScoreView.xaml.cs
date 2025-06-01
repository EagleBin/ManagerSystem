using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompanyManagerSystem.View.subView.InformationManager
{
    /// <summary>
    /// ScoreView.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreView : UserControl
    {
        public ScoreView()
        {
            InitializeComponent();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid != null)
            {
                // 调用上述调整列宽的方法
                AdjustColumnWidths(dataGrid);
            }
        }

        private void AdjustColumnWidths(DataGrid dataGrid)
        {
            if (dataGrid == null || dataGrid.Columns.Count == 0) return;
            double totalWidth = dataGrid.ActualWidth - dataGrid.RowHeaderWidth;
            double columnWidth = totalWidth / dataGrid.Columns.Count;
            foreach (var column in dataGrid.Columns)
            {
                column.Width = new DataGridLength(columnWidth);
            }
        }
    }
}
