using System.Windows;

namespace DataSourceSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new DataSourceViewModel();
            InitializeComponent();
        }
    }
}
