using CursProjects_GIt.Model.Logic;
using CursProjects_GIt.View.Administrator;
using CursProjects_GIt.ViewModel;
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
            frWin.Navigate(view);
        }
    }
}
