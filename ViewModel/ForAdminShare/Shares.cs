using CursProjects_GIt.Model.DataBase;
using CursProjects_GIt.Model.DataBase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursProjects_GIt.ViewModel.ForAdminShare
{
    public class Shares:ViewBase
    {
        public SharesContext context = new SharesContext();
        private List<Share> _share = new List<Share>();
        public List<Share> Share
        {
            get { return _share; }
            set { _share = value; }


        }



        public Shares()
        {
           
            Share = context.Shares.ToList();
        }
    }
}
