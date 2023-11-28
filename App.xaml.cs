using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CursProjects_GIt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static NavigationService navigator;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.StartupUri =
             new Uri("pack://application:,,,/CursProjects_Git;component/MainWindow.xaml");
        }


        void App_Navigated(object sender, NavigationEventArgs e)
        {
            Page page = e.Content as Page;
            if (page != null)
                ApplicationHelper.NavigationService = page.NavigationService;

        }


        
    }
}
