using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TemaHotel.Model;

namespace TemaHotel.ViewModel
{
    public class UserUtils : INotifyPropertyChanged
    {
        User newUser = new User();
        public event PropertyChangedEventHandler PropertyChanged;
        private string email;
        private string password;
        private string confirmPassword;

        public string Email 
        {
            get { return email; }
            set 
            {
                email = value;
                OnPropertyChanged("Email");
            }
            
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }

        }

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }

        }

        public UserUtils(MenuCommands comm)
        {
           
        }

        public void NewUser(object param)
        {
            SignUp create = new SignUp();
            create.Show();
        }

        public void CreateUserAccount(object param)
        {

            MessageBox.Show("Account created please login");
        }

        public void Login(object param)
        {
            User us = new User();
            MessageBox.Show("You have succesfully logged on");
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
