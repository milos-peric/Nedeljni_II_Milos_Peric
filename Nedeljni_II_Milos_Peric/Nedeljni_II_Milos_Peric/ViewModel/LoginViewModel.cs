using Nedeljni_II_Milos_Peric.Command;
using Nedeljni_II_Milos_Peric.Utility;
using Nedeljni_II_Milos_Peric.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni_II_Milos_Peric.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        private LoginView loginView;
        private const string pathCredentialAccess = @"..\..\ClinicAccess.txt";
        DatabaseService databaseService = new DatabaseService();

        public LoginViewModel(LoginView loginView)
        {
            this.loginView = loginView;
            clinicAdmin = new vwClinicAdmin();
            if (!File.Exists(pathCredentialAccess))
            {
                CredentialsGenerator.WriteCredentialsToFile("admin", "admin");
            }
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

        private vwClinicAdmin clinicAdmin;
        public vwClinicAdmin ClinicAdmin
        {
            get { return clinicAdmin; }
            set
            {
                clinicAdmin = value;
                OnPropertyChanged("ClinicAdmin");
            }
        }

        private ICommand signInCommand;
        public ICommand SignInCommand
        {
            get
            {
                if (signInCommand == null)
                {
                    signInCommand = new RelayCommand(SignInCommandExecute, param => CanSignInCommandExecute());
                }
                return signInCommand;
            }
        }

        private void SignInCommandExecute(object obj)
        {
            try
            {
                string password = (obj as PasswordBox).Password;
                clinicAdmin = databaseService.FindClinicAdminCredentials(UserName, password);
                List<string> credentialsFromFile = CredentialsGenerator.ReadCredentialsFromFile();
                if (UserName.Equals(credentialsFromFile.ElementAt(0)) && password.Equals(credentialsFromFile.ElementAt(1)))
                {
                    MasterView mAdminView = new MasterView();
                    loginView.Close();
                    mAdminView.Show();
                    return;
                }
                else if (clinicAdmin != null)
                {
                    if (clinicAdmin.HasCreatedClinic == null)
                    {
                        AddClinicView addClinicView = new AddClinicView(clinicAdmin);
                        loginView.Close();
                        addClinicView.Show();
                        return;
                    }
                    else
                    {
                        ClinicAdminView clinicAdminView = new ClinicAdminView(clinicAdmin);
                        loginView.Close();
                        clinicAdminView.Show();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Wrong usename or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSignInCommandExecute()
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

        private ICommand registerCommand;
        public ICommand RegisterCommand
        {
            get
            {
                if (registerCommand == null)
                {
                    registerCommand = new RelayCommand(param => RegisterExecute());
                }
                return registerCommand;
            }
        }

        private void RegisterExecute()
        {
            try
            {
                //RegistrationView registerView = new RegistrationView();
                //login.Close();
                //registerView.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
