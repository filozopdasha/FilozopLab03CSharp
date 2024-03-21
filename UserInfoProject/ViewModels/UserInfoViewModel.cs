using FilozopLab03.UserInfoProject.Models;
using FilozopLab03.UserInfoProject.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FilozopLab03.UserInfoProject.ViewModels
{
    class UserInfoViewModel : INotifyPropertyChanged
    {
        private bool _isEnabled = true;
        #region Fields
        private Person _person;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _date;

        private string _userFirstName = "";
        private string _userSurname = "";
        private string _userEmail = "";
        private string _userBirthday = "";
        private string _userIsAdult = "";
        private string _userAge = "";
        private string _userWesternZodiac = "";
        private string _userChineseZodiac = "";
        private bool _enableButton = true;
        private RelayCommand<object> _proceedCommand;
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public string UserName
        {
            get
            {
                return _userFirstName;
            }
            set
            {
                _userFirstName = value;
                OnPropertyChanged();
            }
        }
        public string UserSurname
        {
            get
            {
                return _userSurname;
            }
            set
            {
                _userSurname = value;
                OnPropertyChanged();
            }
        }

        public string UserEmail
        {
            get
            {
                return _userEmail;
            }
            set
            {
                _userEmail = value;
                OnPropertyChanged();
            }
        }
        public string UserBirthday
        {
            get
            {
                return _userBirthday;
            }
            set
            {
                _userBirthday = value;
                OnPropertyChanged();
            }
        }
        public string UserIsAdult
        {
            get
            {
                return _userIsAdult;
            }
            set
            {
                _userIsAdult = value;
                OnPropertyChanged();
            }
        }
        public string UserAge
        {
            get
            {
                return _userAge;
            }
            set
            {
                _userAge = value;
                OnPropertyChanged();
            }
        }
        public string UserWesternZodiac
        {
            get
            {
                return _userWesternZodiac;
            }
            set
            {
                _userWesternZodiac = value;
                OnPropertyChanged();
            }
        }
        public string UserChineseZodiac
        {
            get
            {
                return _userChineseZodiac;
            }
            set
            {
                _userChineseZodiac = value;
                OnPropertyChanged();
            }
        }

        public bool ProceedEnabled
        {
            get
            {
                return _enableButton;
            }
            set
            {
                _enableButton = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private async void InformationProceedCommand(object obj)
        {
            UserName = "";
            UserSurname = "";
            UserEmail = "";
            UserBirthday = "";
            UserIsAdult = "";
            UserAge = "";
            UserWesternZodiac = "";
            UserChineseZodiac = "";

            try
            {
                IsEnabled = false;
                await Task.Run(() => {
                    Thread.Sleep(3000);
                    Person = new Person(Name, Surname, Email, Date);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally { IsEnabled = true; }

            UserName = Person.FirstName;
            UserSurname = Person.LastName;
            UserEmail = Person.EmailAddress;
            UserBirthday = Person.DateOfBirth.ToString("dd/MM/yyyy");
            UserIsAdult = Person.IsAdult.ToString();
            UserAge = Person.IsBirthday.ToString();
            UserWesternZodiac = Person.WesternSign;
            UserChineseZodiac = Person.ChineseSign;

            if (Person.IsBirthday)
            {
                MessageBox.Show("It is your birthday!");
            }
        }


        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Name)
                && !string.IsNullOrWhiteSpace(Surname)
                && !string.IsNullOrWhiteSpace(Email)
                && Date != default(DateTime);
        }


        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(InformationProceedCommand, _ => CanExecute());
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}