using CursProjects_GIt.Model.DataBase;
using CursProjects_GIt.Model.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CursProjects_GIt.ViewModel
{
    public enum Priority
    {
        Company,
        Person,

    }
    public class ViewShareHolders:ViewBase
    {
        private ObservableCollection<ShareHolders> _shareHolders = new ObservableCollection<ShareHolders>();

        public ObservableCollection<ShareHolders> ShareHolders {
            get {  return _shareHolders; }
            set { _shareHolders = value; }
        
        
        }

        public ViewShareHolders()
        {
            CompanyVisible = "Hidden";
            PersonVisible = "Hidden";

        }


        Priority priority = Priority.Company;

        public Priority Priority
        {
            get { return priority; }
            set
            {
                if (priority == value)
                    return;

                priority = value;
                OnPropertyChanged("Priority");
                OnPropertyChanged("IsCompanyPriority");
                OnPropertyChanged("IsPersonPriority");
                
                OnPropertyChanged("GetResult");
            }
        }

        public bool IsCompanyPriority
        {
            get { return Priority == Priority.Company; }
            set 
            { 
               
                Priority = value ? Priority.Company : Priority;
                GetWin("Компания");
            
            }
        }

        public bool IsPersonPriority
        {
            get { return Priority == Priority.Person; }
            set 
            { 
                Priority = value ? Priority.Person : Priority;
                GetWin("Частный инвестор");

            }
        }




        public string GetResult
        {
            get
            {
                switch (Priority)
                {
                    case Priority.Company:
                        GetWin("Компания");
                        return "Компания";
                    case Priority.Person:
                        GetWin("Частный инвестор");
                        return "Частный инвестор";
                    
                }
                return "";
            }
        }



        private string _personVisible = null;
        public string PersonVisible
        {
            get
            {
                return _personVisible;
            }

            set
            {
                _personVisible = value;
                OnPropertyChanged(PersonVisible);
            }
        }




        private string _companyVisible = null;
        public string CompanyVisible
        {
            get
            {
                return _companyVisible;
            }

            set
            {
                _companyVisible = value;
                OnPropertyChanged(CompanyVisible);
            }
        }




        public void GetWin(string type)
        {
            if (type == "Компания")
            {
                CompanyVisible = "Visible";
                PersonVisible = "Hidden";
                OnPropertyChanged(CompanyVisible);
                OnPropertyChanged(PersonVisible);

            }
            else if(type =="Частный инвестор")
            {
                PersonVisible = "Visible";
                CompanyVisible = "Hidden";

                OnPropertyChanged(CompanyVisible);
                OnPropertyChanged(PersonVisible);
            }

            else
            {
                CompanyVisible = "Visible";
                PersonVisible = "Hidden";
            }
        }
    }
}
