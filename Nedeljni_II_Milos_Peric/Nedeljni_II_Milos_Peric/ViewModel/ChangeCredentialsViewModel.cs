using Nedeljni_II_Milos_Peric.Command;
using Nedeljni_II_Milos_Peric.Utility;
using Nedeljni_II_Milos_Peric.Validation;
using Nedeljni_II_Milos_Peric.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni_II_Milos_Peric.ViewModel
{
    class ChangeCredentialsViewModel : ViewModelBase
    {
        private ChangeCredentialsView changeCredentialsView;

        public ChangeCredentialsViewModel(ChangeCredentialsView changeCredentialsView)
        {
            this.changeCredentialsView = changeCredentialsView;
        }

        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private ICommand changeCredentialsCommand;
        public ICommand ChangeCredentialsCommand
        {
            get
            {
                if (changeCredentialsCommand == null)
                {
                    changeCredentialsCommand = new RelayCommand(ChangeCredentialsCommandExecute, param => CanChangeCredentialsCommandExecute());
                }
                return changeCredentialsCommand;
            }
        }

        private void ChangeCredentialsCommandExecute(object obj)
        {
            try
            {
                string password = (obj as PasswordBox).Password;
                if (PasswordValidator.ValidatePassword(password))
                {
                    CredentialsGenerator.WriteCredentialsToFile(UserName, password);
                    MessageBox.Show("Credentials changed successfully!", "Info");
                    changeCredentialsView.Close();
                }
                else
                {
                    MessageBox.Show("Password is not secure enough!", "Info");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanChangeCredentialsCommandExecute()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new RelayCommand(param => CancelCommandExecute());
                }
                return cancelCommand;
            }
        }

        private void CancelCommandExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to close window?", "Close Window", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        changeCredentialsView.Close();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
