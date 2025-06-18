using Syncfusion.UI.Xaml.Grid;
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

namespace WPFDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PART_VisualContainer_Loaded(object sender, RoutedEventArgs e)
        {
            var visualcontainer = sender as VisualContainer;
            visualcontainer.RowHeights.DefaultLineSize = 120;
            visualcontainer.RowHeights[0] = 120;
            visualcontainer.ColumnWidths.DefaultLineSize = 30;
        }
    }
}
