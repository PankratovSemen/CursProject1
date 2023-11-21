using CursProjects_GIt.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursProjects_GIt.ViewModel
{
    public class ViewShareHolders:ViewBase
    {
        private ObservableCollection<ShareHolders> _shareHolders = new ObservableCollection<ShareHolders>();

        public ObservableCollection<ShareHolders> ShareHolders {
            get {  return _shareHolders; }
            set { _shareHolders = value; }
        
        
        }
    }
}
