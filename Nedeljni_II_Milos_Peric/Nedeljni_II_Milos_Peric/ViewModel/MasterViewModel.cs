using Nedeljni_II_Milos_Peric.Command;
using Nedeljni_II_Milos_Peric.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni_II_Milos_Peric.ViewModel
{
    class MasterViewModel
    {
        private MasterView masterView;

        public MasterViewModel(MasterView masterView)
        {
            this.masterView = masterView;
        }

        private ICommand addClinicAdministratorCommand;
        public ICommand AddClinicAdministratorCommand
        {
            get
            {
                if (addClinicAdministratorCommand == null)
                {
                    addClinicAdministratorCommand = new RelayCommand(param => AddClinicAdministratorCommandExecute());
                }
                return addClinicAdministratorCommand;
            }
        }

        private void AddClinicAdministratorCommandExecute()
        {
            try
            {
                AddClinicAdministratorView addClinicAdmin = new AddClinicAdministratorView();
                addClinicAdmin.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private ICommand changeCredentialsCommand;
        public ICommand ChangeCredentialsCommand
        {
            get
            {
                if (changeCredentialsCommand == null)
                {
                    changeCredentialsCommand = new RelayCommand(param => ChangeCredentialsCommandExecute());
                }
                return changeCredentialsCommand;
            }
        }

        private void ChangeCredentialsCommandExecute()
        {
            try
            {
                ChangeCredentialsView changeCredentialsView = new ChangeCredentialsView();
                changeCredentialsView.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private ICommand logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                if (logoutCommand == null)
                {
                    logoutCommand = new RelayCommand(param => Logout());
                    return logoutCommand;
                }
                return logoutCommand;
            }
        }

        public void Logout()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        LoginView loginView = new LoginView();
                        Thread.Sleep(1000);
                        masterView.Close();
                        loginView.Show();
                        return;
                    case MessageBoxResult.Cancel:
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
