using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Lands.ViewModels
{
    public class LoginViewModel
    {
        #region Properties
        
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        private bool isRunning;

        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }
        private bool isRemembered;
        public bool IsRemembered
        {
            get { return isRemembered; }
            set { isRemembered = value; }
        }
        #endregion
        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
        }
        #endregion

        #region Commands

        #endregion

        public ICommand LoginCommand {
            get;
            set;
        }
        public ICommand RegisterCommand
        {
            get;
            set;
        }
    }
}
