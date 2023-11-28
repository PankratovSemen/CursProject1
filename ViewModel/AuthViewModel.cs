using CursProjects_GIt.Model.Commands;
using CursProjects_GIt.Model.DataBase;
using CursProjects_GIt.Model.DataBase.Context;
using CursProjects_GIt.Model.Logic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;

namespace CursProjects_GIt.ViewModel
{
    public class AuthViewModel : ViewBase
    {
        public ApplicationContext db = new ApplicationContext();
        public AuthViewModel()
        {
            db.Users.Load();
            swithWindow("Авторизация");
            int s = db.Users.Count();
            if (s == 0)
            {
                UsersModel user = new UsersModel()
                {
                    Name = "Семён",
                    Surname = "Панкратов",
                    Email = "simen204@mail.ru",
                    Password = "admin",
                    Role = "Администратор"
                };

                db.Users.Add(user);
                db.SaveChanges();
            }

        }
        //Статус окна регистрации
        private string _registerVisibile;
        public string RegisterVisible
        {
            get { return _registerVisibile; }
            set
            {
                _registerVisibile = value;

                OnPropertyChanged(nameof(RegisterVisible));

            }
        }
        private void swithWindow(string title)
        {
            if (title == "Авторизация")
            {
                AuthVisible = "Visible";
                RegisterVisible = "Hidden";
            }
            else if (title == "Регистрация")
            {
                AuthVisible = "Hidden";
                RegisterVisible = "Visible";
            }
        }
        //Статус окна авторизации
        private string _authVisible;
        public string AuthVisible
        {
            get { return _authVisible; }
            set
            {
                _authVisible = value;

                OnPropertyChanged(nameof(AuthVisible));

            }
        }
        //Password
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;

                OnPropertyChanged(nameof(Password));

            }
        }

        //Login

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }






        private RelayCommand loginsys;
        public RelayCommand Loginsys
        {
            get
            {
                return loginsys ??
                  (loginsys = new RelayCommand(obj =>
                  {

                      // получаем объекты из бводим на консоль
                      var users = db.Users.ToList();
                      var vals = users.FirstOrDefault(p => p.Email == _login);
                      string s = _login;
                      MessageBox.Show(s);
                      if (vals != null)
                      {
                          SystemWin system = new SystemWin();
                          system.Role = vals.Role;
                          system.Show();
                          Data data = new Data();
                          data.Role = vals.Role;
                         



                      }
                      else
                      {

                          MessageBox.Show("no");
                      }


                  }));
            }
        }

        //Register command Navigate
        private RelayCommand _registerCommand;
        public RelayCommand RegisterCommand
        {
            get
            {
                return _registerCommand ??
                  (_registerCommand = new RelayCommand(obj =>
                  {

                      swithWindow("Регистрация");


                  }));
            }
        }

        //Домой команда "назад"
        //Register command Navigate
        private RelayCommand _backAuth;
        public RelayCommand BackAuth
        {
            get
            {
                return _backAuth ??
                  (_backAuth = new RelayCommand(obj =>
                  {

                      swithWindow("Авторизация");


                  }));
            }
        }


        //Значения для окна регистрации
        private string _nameReg;
        public string NameReg
        {
            get { return _nameReg; }
            set
            {
                _nameReg = value;
                OnPropertyChanged(nameof(NameReg));
            }
        }


        //Surname value
        private string _surnameReg;
        public string SurnameReg
        {
            get { return _surnameReg; }
            set
            {
                _surnameReg = value;
                OnPropertyChanged(nameof(SurnameReg));
            }
        }



        //Email value
        private string _emailReg;
        public string EmailReg
        {
            get { return _emailReg; }
            set
            {
                _emailReg = value;
                OnPropertyChanged(nameof(EmailReg));
            }
        }


        //Значения для окна регистрации
        private string _passwordReg;
        public string PasswordReg
        {
            get { return _passwordReg; }
            set
            {
                _passwordReg = value;
                OnPropertyChanged(nameof(NameReg));
            }
        }

    }






}




