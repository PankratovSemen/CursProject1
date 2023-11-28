using CursProjects_GIt.Model.Commands;
using CursProjects_GIt.Model.DataBase;
using CursProjects_GIt.Model.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Windows;
using System.Windows.Documents;

namespace CursProjects_GIt.ViewModel
{
    
    public enum Priority
    {
        Company,
        Person,

    }
    public class ViewShareHolders : ViewBase
    {
        public ApplicationContext db = new ApplicationContext();
        public ShareHoldersContext shareHoldContext = new ShareHoldersContext();
        public SharesContext shareContext = new SharesContext();
        private List<ShareHolders> _shareHolders = new List<ShareHolders>();

        public List<ShareHolders> ShareHolders
        {
            get { return _shareHolders; }
            set { _shareHolders = value; }


        }

        private ShareHolders _selectedSH;
        public ShareHolders SelectedSH
        {
            get
            {
                return _selectedSH;
            }
            set
            {
                _selectedSH = value;
                OnPropertyChanged(nameof(SelectedSH));
            }
        }
        

        public ViewShareHolders()
        {
            PersonVisible = "Hidden";
            CompanyVisible = "Visible";
            Win = "Visible";
            WinCreate = "Hidden";
            EditVisible = "Hidden";
            ShareHolders = shareHoldContext.ShareHolders.ToList();
            OnPropertyChanged(nameof(ShareHolders));

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
                GetWin(1);

            }
        }

        public bool IsPersonPriority
        {
            get { return Priority == Priority.Person; }
            set
            {
                GetWin(2);
                Priority = value ? Priority.Person : Priority;


            }
        }




        public string GetResult
        {
            get
            {
                switch (Priority)
                {
                    case Priority.Company:
                        {

                            GetWin(1);
                            return "Компания";
                        }


                    case Priority.Person:
                        {
                            MessageBox.Show("Частный инвестор");
                            GetWin(2);
                            return "Частный инвестор";
                        }


                }
                return "";
            }
        }



        private string _personVisible;
        public string PersonVisible
        {
            get
            {
                return _personVisible;
            }
            set
            {
                _personVisible = value;
                OnPropertyChanged(nameof(PersonVisible));
            }
        }





        private string _companyVisible;
        public string CompanyVisible
        {
            get
            {
                return _companyVisible;
            }
            set
            {
                _companyVisible = value;
                OnPropertyChanged(nameof(CompanyVisible));
            }
        }




        public void GetWin(int type)
        {
            if (type == 1)
            {
                CompanyVisible = "Visible";
                PersonVisible = "Hidden";


            }
            else if (type == 2)
            {

                PersonVisible = "Visible";
                CompanyVisible = "Hidden";


            }

            //else
            //{
            //    CompanyVisible = "Visible";
            //    PersonVisible = "Hidden";
            //    OnPropertyChanged(CompanyVisible);
            //    OnPropertyChanged(PersonVisible);
            //}
        }


        //Данные для заполнения информации о компании
        private string _titleCompany;
        public string TitleCompany
        {
            get { return _titleCompany; }
            set
            {
                _titleCompany = value; OnPropertyChanged(nameof(TitleCompany));
            }
        }


        //Данные для заполнения частного инвестора
        private string _surname;
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value; OnPropertyChanged();
            }
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value; OnPropertyChanged();
            }
        }
        private string _middlename;
        public string MiddleName
        {
            get
            {
                return _middlename;
            }
            set
            {
                _middlename = value; OnPropertyChanged();
            }
        }

        ///Комманды для добавления заисей. Добавление записей

        private RelayCommand _addCompany;
        public RelayCommand AddCompany
        {
            get
            {
                return _addCompany ??
                  (_addCompany = new RelayCommand(obj =>
                  {
                      ShareHolders shareHolders = new ShareHolders()
                      {
                          Title = TitleCompany,
                          Status = "Действующий",
                          DateJoin = DateTime.UtcNow
                      };
                      
                      shareHoldContext.ShareHolders.Add(shareHolders);
                      shareHoldContext.SaveChanges();
                      


                  }));
            }
        }
        private RelayCommand _addPerson;
        public RelayCommand AddPerson
        {
            get
            {
                return _addPerson ??
                  (_addPerson = new RelayCommand(obj =>
                  {
                      ShareHolders shareHolders = new ShareHolders()
                      {
                          Title = Surname + " " + Name + " " + MiddleName,
                          Surname = Surname,
                          Name = Name,
                          MiddleName = MiddleName,
                          Status = "Действующий",
                          DateJoin = DateTime.UtcNow
                      };
                      shareHoldContext.ShareHolders.Add(shareHolders);
                      shareHoldContext.SaveChanges();
                      


                  }));
            }
        }



        public string Win { get; set; }
        public string WinCreate { get; set; }





        //Окна
        private RelayCommand _viewVisibleCommand;
        public RelayCommand ViewVisibleCommand
        {
            get
            {
                return _viewVisibleCommand ??
                  (_viewVisibleCommand = new RelayCommand(obj =>
                  {
                      Win = "Visible";
                      WinCreate = "Hidden";
                      EditVisible = "Hidden";
                      OnPropertyChanged(nameof(Win));
                      OnPropertyChanged(nameof(WinCreate));
                      ShareHolders = shareHoldContext.ShareHolders.ToList();
                      OnPropertyChanged(nameof(ShareHolders));


                  }));
            }
        }



        private RelayCommand _createVisibleCommand;
        public RelayCommand CreateVisibleCommand
        {
            get
            {
                return _createVisibleCommand ??
                  (_createVisibleCommand = new RelayCommand(obj =>
                  {
                      WinCreate = "Visible";
                      Win = "Hidden";
                      EditVisible = "Hidden";
                      OnPropertyChanged(nameof(Win));
                      OnPropertyChanged(nameof(WinCreate));
                      ShareHolders = shareHoldContext.ShareHolders.ToList();
                      OnPropertyChanged(nameof(ShareHolders));


                  }));
            }
        }
        

        //Command for delete item in datagrid
        private RelayCommand _deleteitem;
        public RelayCommand DeleteItem
        {
            get
            {
                return _deleteitem ??
                    (_deleteitem = new RelayCommand(obj =>
                    {
                        shareHoldContext.Remove(SelectedSH);
                        shareHoldContext.SaveChanges();
                        ShareHolders = shareHoldContext.ShareHolders.ToList();
                        OnPropertyChanged(nameof(ShareHolders));
                    }));

            }
        }


        //View Edit 
        private string _editVisible;
        public string EditVisible
        {
            get
            {
                return _editVisible;
            }

            set
            {
                _editVisible = value;
                OnPropertyChanged(nameof(EditVisible));
            }
        }


        //Command for switch between screen Edit
        private RelayCommand _editVisibleCommand;
        public RelayCommand EditVisibleCommand
        {
            get
            {
                return _editVisibleCommand ??
                  (_editVisibleCommand = new RelayCommand(obj =>
                  {
                      WinCreate = "Hidden";
                      Win = "Hidden";
                      EditVisible = "Visible";
                      OnPropertyChanged(nameof(Win));
                      OnPropertyChanged(nameof(WinCreate));
                      OnPropertyChanged(nameof(EditVisible));

                      EditShareHolder = SelectedSH.Title;

                  }));
            }
        }

        //Variable for edit
        private string _editShareHolder;
        public string EditShareHolder
        {
            get
            {
                return _editShareHolder;
            }

            set
            {
                _editShareHolder = value;
                OnPropertyChanged(nameof(EditShareHolder));
            }
        }


        //Command for Edit value
        private RelayCommand _editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ??
                  (_editCommand = new RelayCommand(obj =>
                  {
                      SelectedSH.Title = EditShareHolder;
                      shareHoldContext.ShareHolders.Update(SelectedSH);
                      shareHoldContext.SaveChanges();
                      ShareHolders = shareHoldContext.ShareHolders.ToList();
                      OnPropertyChanged(nameof(ShareHolders));
                      EditShareHolder = "";


                      WinCreate = "Hidden";
                      Win = "Visible";
                      EditVisible = "Hidden";
                      OnPropertyChanged(nameof(Win));
                      OnPropertyChanged(nameof(WinCreate));
                      OnPropertyChanged(nameof(EditVisible));

                  }));
            }
        }


        public string Role { get; set; }
    }
}

