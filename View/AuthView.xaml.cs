using CursProjects_GIt.ViewModel;
using System.Windows.Controls;

namespace CursProjects_GIt.View
{
    /// <summary>
    /// Логика взаимодействия для AuthView.xaml
    /// </summary>
    public partial class AuthView : Page
    {
        public AuthView()
        {
            InitializeComponent();
            AuthViewModel view = new AuthViewModel();
            DataContext = view;
        }
    }
}
