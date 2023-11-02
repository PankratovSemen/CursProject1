using CursProjects_GIt.Model.Commands;
using CursProjects_GIt.Model.DataBase;
using CursProjects_GIt.Model.DataBase.Context;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CursProjects_GIt.ViewModel
{
    public class AuthViewModel:INotifyPropertyChanged
    {
        
        //Password
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value;

                OnPropertyChanged(nameof(Password));

            }
        }

        //Login

        private string _login;
        public string Login
        {
            get { return _login; }
            set { _login = value;
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
                      using (ApplicationContext db = new ApplicationContext())
                      {
                          // получаем объекты из бводим на консоль
                          var users = db.Users.ToList();
                          var vals = users.FirstOrDefault(p => p.Email == _login);
                          string s = _logins;
                          MessageBox.Show(s);
                          if (vals != null)
                          {
                              MessageBox.Show("Ok");
                              MessageBox.Show(vals.Email);
                          }
                          else
                          {
                              
                              MessageBox.Show("no");
                          }
                          
                      }
                  }));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
