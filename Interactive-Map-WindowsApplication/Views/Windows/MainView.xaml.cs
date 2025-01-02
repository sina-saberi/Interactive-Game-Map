using Interactive_Map_WindowsApplication.ViewModels.Windows;
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
using System.Windows.Shapes;

namespace Interactive_Map_WindowsApplication.Views.Windows
{
    public partial class MainView : Window
    {
        public MainView(MainViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
