using CursProjects_GIt.Model.Commands;
using CursProjects_GIt.Model.DataBase;
using CursProjects_GIt.Model.DataBase.Context;
using CursProjects_GIt.Model.Logic;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CursProjects_GIt.ViewModel
{
    public class UsersViewModel : ViewBase
    {
        public ApplicationContext context = new ApplicationContext();

        public UsersViewModel()
        {
            Users = context.Users.ToList();
            OnPropertyChanged(nameof(Users));

            View = "Visible";
            Create = "Hidden";
            OnPropertyChanged(nameof(View));
            OnPropertyChanged(nameof(Create));
            Data data = new Data();
            SystemWin win = new SystemWin();
            MessageBox.Show(data.Role);
        }

        private List<UsersModel> _users = new List<UsersModel>();
        public List<UsersModel> Users
        {
            get
            {
                return _users;
            }

            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }


        private UsersModel _selectedUsers;
        public UsersModel SelectedUsers
        {
            get
            {
                return _selectedUsers;
            }
            set
            {
                _selectedUsers = value;
                OnPropertyChanged(nameof(SelectedUsers));
            }
        }


        private RelayCommand _deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return _deleteItem ??
                    (_deleteItem = new RelayCommand(obj =>
                    {
                        int s = context.Users.Where(x => x.Role == "Администратор").Count();
                        int userscount = context.Users.Max(x => x.Id);
                        if (s > 1)
                        {
                            context.Users.Remove(SelectedUsers);
                            context.SaveChanges();
                            Users = context.Users.ToList();
                            OnPropertyChanged(nameof(Users));
                            MessageBox.Show(userscount.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Невозможно удалить пользователя являющиеся администратором");
                        }

                    }));
            }
        }

        //Variable for create data auth

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }


        private string _surname;
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }


        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }


        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        private string _role;
        public string Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }



        private RelayCommand _newUser;
        public RelayCommand NewUser
        {
            get
            {
                return _newUser ??
                    (_newUser = new RelayCommand(obj =>
                    {
                        UsersModel user = new UsersModel()
                        {
                            Name = Name,
                            Surname = Surname,
                            Email = Email,
                            Password = Password,
                            Role = Role
                        };

                        context.Users.Add(user);
                        context.SaveChanges();
                    }));
            }
        }



        private RelayCommand _nextCreate;
        public RelayCommand NextCreate
        {
            get
            {
                return _nextCreate ??
                    (_nextCreate = new RelayCommand(obj =>
                    {
                        View = "Hidden";
                        Create = "Visible";
                        OnPropertyChanged(nameof(View));
                        OnPropertyChanged(nameof(Create));
                    }));
            }
        }
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
        private string _create;
        public string Create
        {
            get
            {
                return _create;
            }

            set
            {
                _create = value;
                OnPropertyChanged(nameof(Create));
            }
        }
    }
}
