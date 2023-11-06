//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Navigation;
//using System.Windows;

//namespace CursProjects_GIt.ViewModel
//{
//    public class NavigationViewModel: INotifyPropertyChanged
//    {
//        public event PropertyChangedEventHandler PropertyChanged;

//        private ObservableCollection<NavigationItem> _navigationItems;
//        public ObservableCollection<NavigationItem> NavigationItems
//        {
//            get { return _navigationItems; }
//            set
//            {
//                _navigationItems = value;
//                OnPropertyChanged("NavigationItems");
//            }
//        }

//        private NavigationItem _selectedItem;
//        public NavigationItem SelectedItem
//        {
//            get { return _selectedItem; }
//            set
//            {
//                _selectedItem = value;
//                NavigateToPage(_selectedItem);
//                OnPropertyChanged("SelectedItem");
//            }
//        }

//        private Stack<NavigationItem> _backStack;
//        private NavigationItem _currentPage;

//        public NavigationViewModel()
//        {
//            _navigationItems = new ObservableCollection<NavigationItem>();
//            _backStack = new Stack<NavigationItem>();
//        }

//        private void NavigateToPage(NavigationItem item)
//        {
//            var page = GetPage(item.PageName);
//            if (page == null) return;

//            // Create corresponding view model
//            var viewModel = GetViewModel(page);
//            if (viewModel == null) return;

//            // Set view model as data context
//            page.DataContext = viewModel;

//            // Add to back stack
//            _backStack.Push(_currentPage);

//            // Navigate to page
//            _currentPage = item;
//            NavigationService.NavigateTo(page);
//        }

//        private object GetPage(string pageName)
//        {
//            // Search for page in application resources
//            var pageResource = $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Pages/{pageName}.xaml";

//            var page = Application.LoadComponent(new Uri(pageResource)) as Page;
//            return page;
//        }

//        private object GetViewModel(object page)
//        {
//            // Try to find view model as a resource of the page
//            var viewModel = (page as FrameworkElement)?.DataContext;
//            if (viewModel == null) return null;

//            if (!(_currentPage.PageName == "Settings" && _backStack.Count > 0 && _backStack.Peek().PageName == "Settings"))
//            {
//                // Refresh view model state if settings page is being loaded
//                (viewModel as IRefreshable)?.Refresh();
//            }

//            return viewModel;
//        }

//        private void OnPropertyChanged(string propertyName)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }
//    }
//}
