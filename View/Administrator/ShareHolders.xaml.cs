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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
