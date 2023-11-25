using CursProjects_GIt.ViewModel;
using System.Windows;

namespace CursProjects_GIt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AuthViewModel context = new AuthViewModel();
            DataContext = context;
        }


    }
}
