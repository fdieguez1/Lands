using GalaSoft.MvvmLight.Command;
using Lands.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        #region Properties

        private string email;
        public string Email
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }

        private bool isRunning;
        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }

        private bool isRemembered;
        public bool IsRemembered
        {
            get { return isRemembered; }
            set { isRemembered = value; }
        }

        private bool isEnabledBool;
        public bool IsEnabledBool
        {
            get { return isEnabledBool; }
            set { SetValue(ref isEnabledBool, value); }
        }
        #endregion
        #region Constructors
        public LoginViewModel()
        {
            IsRemembered = true;
            isEnabledBool = true;
            //http://restcountries.eu/rest/v2/all
            Email = "prueba@gmail.com";
            Password = "1234";

        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an e-mail",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password",
                    "Accept");
                return;
            }
            IsRunning = true;

            if (Email != "prueba@gmail.com" || Password != "1234")
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password incorrect",
                    "Accept");
                Password = string.Empty;
                IsRunning = false;
                return;
            }
            Password = string.Empty;
            IsRunning = false;

            Email = string.Empty;
            Password = string.Empty;
            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }

        public ICommand RegisterCommand
        {
            get;
        }
        #endregion
    }
}
