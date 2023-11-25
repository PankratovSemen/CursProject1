using CursProjects_GIt.ViewModel;
using System.Windows.Controls;

namespace CursProjects_GIt.View.Administrator
{
    /// <summary>
    /// Логика взаимодействия для ShareHolders.xaml
    /// </summary>
    public partial class ShareHolders : Page
    {
        public ShareHolders()
        {
            InitializeComponent();
            ViewShareHolders view = new();
            DataContext = view;
        }
    }
}
