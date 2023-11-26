using CursProjects_GIt.Model.Commands;
using CursProjects_GIt.Model.DataBase;
using CursProjects_GIt.Model.DataBase.Context;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CursProjects_GIt.ViewModel.ForAdminShare
{
    public class Shares:ViewBase
    {
        public SharesContext context = new SharesContext();
        public ShareHoldersContext contextHolder = new ShareHoldersContext();
        private List<Share> _share = new List<Share>();
        public List<Share> Share
        {
            get { return _share; }
            set { _share = value; }


        }

        


        public Shares()
        {
           
            Share = context.Shares.ToList();
            Date = DateTime.Now;
            Switch(0);
        }



        private RelayCommand _addShare;
        public RelayCommand AddShare
        {
            get
            {
                return _addShare ??
                  (_addShare = new RelayCommand(obj =>
                  {
                      Share share = new Share()
                      {
                          Title = Date.ToString() + " " + Shareholder,
                          ShareHolder = Shareholder,
                          Sum = Sum,
                          Date = Date,
                          Status = Status
                      };
                      context.Shares.Add(share);
                      context.SaveChanges();
                      ShareHolders holder = contextHolder.ShareHolders.Where(x => x.Title == Shareholder).FirstOrDefault();
                      MessageBox.Show(holder.Id.ToString());
                      MessageBox.Show(holder.SumShare.ToString());
                      
                          if (holder.SumShare == null)
                          {
                            MessageBox.Show("gss");
                              holder.SumShare = Sum;
                              holder.CountShares = 1;
                              contextHolder.ShareHolders.Update(holder);
                              contextHolder.SaveChanges();
                          }
                          else
                          {
                              holder.SumShare = Sum + holder.SumShare;
                              holder.CountShares++;
                              contextHolder.ShareHolders.Update(holder);
                              contextHolder.SaveChanges();
                          }
                      
                      //foreach(var s in sh)
                      //{
                      //    if (s.SumShare == 0)
                      //    {
                      //        MessageBox.Show(s.Id.ToString());
                      //        ShareHolders holders = new ShareHolders()
                      //        {
                      //            Id = s.Id,
                      //            Title = s.Title,
                      //            Name = s.Name,
                      //            Surname = s.Surname,
                      //            MiddleName = s.MiddleName,
                      //            SumShare = Sum,
                      //            CountShares = 1,
                      //            Status = "Действующий",
                      //            DateJoin = s.DateJoin
                      //        }; 
                      //        contextHolder.ShareHolders.Update(holders);
                      //        contextHolder.SaveChanges();
                      //    }
                      //}

                      
                      


                  }));
            }
        }

       

        


        //ShareHolder
        private string _shareholder;
        public string Shareholder
        {
            get
            {
                return _shareholder;
            }
            set
            {
                _shareholder = value;
                OnPropertyChanged(nameof(Shareholder));
            }
        }


        //SumShare

        private int _sum;

        public int Sum
        {
            get
            {
                return _sum;

            }

            set
            {
                _sum = value;
                OnPropertyChanged(nameof(_sum));

            }
        }
        //Date transaction
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }

        }



        public string Status
        {
            get
            {
                return "Не подтверждено";
            }
        }
        //Visability Screens

        //View screen
        private string _view;
        public string View
        {
            get
            {
                return _view;
            }

            set
            {
                _view = value;
                OnPropertyChanged(nameof(View));

            }
        }
        //Create notes screen
        private string _createNotes;
        public string CreateNotes
        {
            get
            {
                return _createNotes;
            }

            set
            {
                _createNotes = value;
                OnPropertyChanged(nameof(CreateNotes));

            }
        }


        public void Switch(int screen)
        {
            if(screen == 0)
            {
                View = "Visible";
                CreateNotes = "Hidden";
            }

            else if(screen == 1)
            {
                View = "Hidden";
                CreateNotes = "Visible";
            }
        }


        //Command for switch between screens 
        //Command for switch in View
        private RelayCommand _viewCommand;
        public RelayCommand ViewCommand
        {
            get
            {
                return _viewCommand ??
                    (_viewCommand = new RelayCommand(obj =>
                    {
                        Switch(0);
                        Share = context.Shares.ToList();

                    }));
            }
        }
        //Command for switch in Create screen 
        private RelayCommand _createNoteCommand;
        public RelayCommand CreateNoteCommand
        {
            get
            {
                return _createNoteCommand ??
                    (_createNoteCommand = new RelayCommand(obj =>
                    {
                        Switch(1);
                        Share = context.Shares.ToList();
                    }));
            }
        }
        //Selected item in variable
        private Share _selectedshare;
        public Share SelectedShare
        {
            get
            {
                return _selectedshare;
            }

            set
            {
                _selectedshare = value;
                OnPropertyChanged(nameof(SelectedShare));
            }
        }


        //Command for delete row in datagrid

        private RelayCommand _deleteShare;
        public RelayCommand DeleteShare
        {
            get
            {
                return _deleteShare ??
                    (_deleteShare = new RelayCommand(obj =>
                    {
                        
                        context.Shares.Remove(SelectedShare);
                        context.SaveChanges();
                        Share = context.Shares.ToList();
                        OnPropertyChanged(nameof(Share));
                    }));
            }
        }



        //Command confirm

        private RelayCommand _confirmCommand;
        public RelayCommand ConfirmCommand
        {
            get
            {
                return _confirmCommand ??
                    (_confirmCommand = new RelayCommand(obj =>
                    {
                        SelectedShare.Status = "Подтверждено";
                        context.Shares.Update(SelectedShare);
                        context.SaveChanges();
                        Share = context.Shares.ToList();
                        OnPropertyChanged(nameof(Share));
                    }));
            }
        }


    }
}
