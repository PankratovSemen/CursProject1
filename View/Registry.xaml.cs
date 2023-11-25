using CursProjects_GIt.ViewModel;
using System.Windows.Controls;

namespace CursProjects_GIt.View
{
    /// <summary>
    /// Логика взаимодействия для Registry.xaml
    /// </summary>
    public partial class Registry : Page
    {
        public Registry()
        {
            InitializeComponent();
            RegViewModel viewModel = new RegViewModel();
            DataContext = viewModel;
        }
    }
}
