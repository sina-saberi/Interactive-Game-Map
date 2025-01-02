using Interactive_Map.ViewModels;
using System.Windows;

namespace Interactive_Map;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel mainViewModel)
    {
        DataContext = mainViewModel;
        InitializeComponent();
    }
}