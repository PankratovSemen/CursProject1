using CursProjects_GIt.View;
using CursProjects_GIt.View.Administrator;
using System.Windows;

namespace CursProjects_GIt
{
    /// <summary>
    /// Логика взаимодействия для SystemWin.xaml
    /// </summary>
    public partial class SystemWin : Window
    {
        public string Role;
        public SystemWin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShareHolders view = new ShareHolders();
            frWin.NavigationService.Navigate(view);
            Roled.Text = Role;

            if (Role == "Администратор")
            {
                Share.Visibility = Visibility.Hidden;
                Shareholder.Visibility = Visibility.Visible;
                ShareforHold.Visibility = Visibility.Visible;
                UsersAdds.Visibility = Visibility.Visible;
            }

            else if(Role == "Акционер")
            {
                Share.Visibility = Visibility.Visible;
                Shareholder.Visibility = Visibility.Hidden;
                ShareforHold.Visibility = Visibility.Hidden;
                UsersAdds.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Внимание пользователь роль которого не совпадает со списко ролей");
                Application.Current.Shutdown();
            }
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

        private void UsersAdds_Click(object sender, RoutedEventArgs e)
        {
            UsersView view = new UsersView();
            frWin.NavigationService.Navigate(view);
        }

        private void Share_Click(object sender, RoutedEventArgs e)
        {
            SharesHoldersView view = new SharesHoldersView();
            frWin.NavigationService.Navigate(view);
        }
    }
}
