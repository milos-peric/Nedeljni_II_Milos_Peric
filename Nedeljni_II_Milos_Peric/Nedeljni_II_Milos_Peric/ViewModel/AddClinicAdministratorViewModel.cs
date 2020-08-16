using Nedeljni_II_Milos_Peric.Command;
using Nedeljni_II_Milos_Peric.Utility;
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
    class AddClinicAdministratorViewModel : ViewModelBase
    {
        AddClinicAdministratorView clinicAdministratorView;
        DatabaseService databaseService = new DatabaseService();

        public AddClinicAdministratorViewModel(AddClinicAdministratorView clinicAdministratorView)
        {
            this.clinicAdministratorView = clinicAdministratorView;
            clinicAdmin = new vwClinicAdmin();
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

        private ICommand addClinicAdminCommand;
        public ICommand AddClinicAdminCommand
        {
            get
            {
                if (addClinicAdminCommand == null)
                {
                    addClinicAdminCommand = new RelayCommand(AddClinicAdminCommandExecute, param => CanAddClinicAdminCommandExecute());
                }
                return addClinicAdminCommand;
            }
        }

        private void AddClinicAdminCommandExecute(object obj)
        {
            try
            {
                string password = (obj as PasswordBox).Password;
                string encryptPassword = EncryptionHelper.Encrypt(password);
                clinicAdmin.Password = encryptPassword;
                char userGender = clinicAdmin.Gender.ElementAt(0);
                clinicAdmin.Gender = userGender.ToString();
                databaseService.AddClinicAdministrator(clinicAdmin);
                MessageBox.Show("New doctor registered successfully!", "Info");
                clinicAdministratorView.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddClinicAdminCommandExecute()
        {
            if (string.IsNullOrEmpty(clinicAdmin.FullName)) 

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
                        clinicAdministratorView.Close();
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
