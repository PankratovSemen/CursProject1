using CursProjects_GIt.View.Administrator;
using System.Windows;

namespace CursProjects_GIt
{
    /// <summary>
    /// Логика взаимодействия для SystemWin.xaml
    /// </summary>
    public partial class SystemWin : Window
    {
        public SystemWin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShareHolders view = new ShareHolders();
            frWin.NavigationService.Navigate(view);
        }

        private void Shareholder_Click(object sender, RoutedEventArgs e)
        {
            ShareHolders view = new ShareHolders();
            frWin.NavigationService.Navigate(view);
        }

        private void ShareforHold_Click(object sender, RoutedEventArgs e)
        {
            ShareForAdmin view = new ShareForAdmin();
            frWin.NavigationService.Navigate(view);
        }
    }
}
