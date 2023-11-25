using CursProjects_GIt.Model.Commands;

namespace CursProjects_GIt.ViewModel
{
    public class RegViewModel : ViewBase
    {
        private string _visibleCreate;
        public string VisibleCreate
        {
            get { return _visibleCreate; }
            set { _visibleCreate = value; }
        }
        public RegViewModel()

        {
            Switch("Просмотр");
        }



        private string _visibleView;
        public string VisibleView
        {
            get { return _visibleView; }
            set { _visibleView = value; }
        }


        private void Switch(string name)
        {
            if (name == "Просмотр")
            {
                VisibleView = "Visible";
                VisibleCreate = "Hidden";
            }
            else if (name == "Создание")
            {
                VisibleView = "Hidden";
                VisibleCreate = "Visible";
            }
        }


        private RelayCommand _viewCommand;
        public RelayCommand ViewCommand
        {
            get
            {
                return _viewCommand ??
                  (_viewCommand = new RelayCommand(obj =>
                  {

                      Switch("Просмотр");


                  }));
            }
        }


        private RelayCommand _CreateCommand;
        public RelayCommand CreateCommand
        {
            get
            {
                return _CreateCommand ??
                  (_CreateCommand = new RelayCommand(obj =>
                  {

                      Switch("Создание");


                  }));
            }
        }
    }
}
