
using CursProjects_GIt.ViewModel.ForAdminShare;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CursProjects_GIt.View.Administrator
{
    /// <summary>
    /// Логика взаимодействия для ShareForAdmin.xaml
    /// </summary>
    public partial class ShareForAdmin : Page
    {
        public ShareForAdmin()
        {
            Shares shares = new Shares();
            InitializeComponent();
            DataContext = shares;
        }
    }
}
