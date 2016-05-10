using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TemaHotel.DataAccess;
using TemaHotel.Model;
using TemaHotel.Utilities;

namespace TemaHotel.ViewModel
{
    public class MenuCommands : INotifyPropertyChanged
    {
        private ObservableCollection<ObservableCollection<int>> list;
        private List<Room> rooms = new List<Room>();
        private ICommand signUpCommand;
        private ICommand createUserCommand;
        private ICommand loginCommand;
        private bool isAuthenticated;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public MenuCommands()
        {
            list = new ObservableCollection<ObservableCollection<int>>();
                for (int j = 0; j < 5; j++)
                {
                    List.Add(new ObservableCollection<int>());
                    List[j].Add(j);
                }
           
        }

        public ObservableCollection<ObservableCollection<int>> List
        {
            get { return list; }
            set
            {
                list = value;
                OnPropertyChanged("List");
            }
        }

        public List<Room> Rooms
        {
            get { return rooms; }
            set
            {
                if(rooms == null)
                { 
                    rooms = new List<Room>();
                }
                rooms = value;
                OnPropertyChanged("Rooms");
            }
        }

        public ICommand CreateUserCommand
        {
            get
            {
                if (createUserCommand == null)
                {
                    UserUtils usUtils = new UserUtils(this);
                    createUserCommand = new RelayCommand(usUtils.CreateUserAccount);
                }
                return createUserCommand;
            }

        }

        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    UserUtils usUtils = new UserUtils(this);
                    createUserCommand = new RelayCommand(usUtils.Login);
                }
                return loginCommand;
            }

        }

        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
            set
            {
                isAuthenticated = value;
                OnPropertyChanged("IsAuthenticated");
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public ICommand SignUpCommand
        {
            get
            {
                if (signUpCommand == null)
                { 
                    UserUtils newUs = new UserUtils(this);
                    signUpCommand = new RelayCommand(newUs.NewUser);

                }
                return signUpCommand;
            }
        }


        public void databaseTest(object param)
        {
            UserServiceLayer userInsert = new UserServiceLayer();
            User testus = new User("usertest", "nametest", "emailtest", "Client");
                 userInsert.AddUser(testus);
       //     userInsert.DeleteUser(testus);
       //     List<User> us = userInsert.GetUsers();
            Room rm = new Room(5,"dfg","ert");
            Room rm2 = new Room(6,"fgh","tt");
            Rooms.Add(rm);
            Rooms.Add(rm2);
            List.Add(new ObservableCollection<int>());
            List[List.Count-1].Add(112);
         //   IsAuthenticated = true;
        }
    }
}
