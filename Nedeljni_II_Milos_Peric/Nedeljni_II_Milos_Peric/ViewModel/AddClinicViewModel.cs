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
    class AddClinicViewModel : ViewModelBase
    {
        private AddClinicView addClinicView;
        DatabaseService databaseService = new DatabaseService();

        public AddClinicViewModel(AddClinicView addClinicView, vwClinicAdmin clinicAdminInstance)
        {
            this.addClinicView = addClinicView;
            clinic = new tblClinicInstitution();
            clinicAdmin = clinicAdminInstance;
        }

        private string hasTerrace = "Yes";
        public string HasTerrace
        {
            get { return hasTerrace; }
            set
            {
                hasTerrace = value;
                OnPropertyChanged("HasTerrace");
            }
        }

        private string hasYard = "Yes";
        public string HasYard
        {
            get { return hasYard; }
            set
            {
                hasYard = value;
                OnPropertyChanged("HasYard");
            }
        }

        private tblClinicInstitution clinic;
        public tblClinicInstitution Clinic
        {
            get { return clinic; }
            set
            {
                clinic = value;
                OnPropertyChanged("Clinic");
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


        private ICommand addClinicCommand;
        public ICommand AddClinicCommand
        {
            get
            {
                if (addClinicCommand == null)
                {
                    addClinicCommand = new RelayCommand(AddClinicCommandExecute, param => CanAddClinicCommandExecute());
                }
                return addClinicCommand;
            }
        }

        private void AddClinicCommandExecute(object obj)
        {
            try
            {
                if (hasTerrace == "Yes")
                {
                    clinic.HasTerrace = true;
                }
                else
                {
                    clinic.HasTerrace = false;
                }
                if (hasYard == "Yes")
                {
                    clinic.HasYard = true;
                }
                else
                {
                    clinic.HasYard = false;
                }
                databaseService.AddClinic(clinic);
                MessageBox.Show("New Clinic created successfully, Switching to Admin menu!", "Info");
                
                ClinicAdminView cAdminView = new ClinicAdminView(clinicAdmin);
                addClinicView.Close();
                cAdminView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddClinicCommandExecute()
        {
            if (string.IsNullOrEmpty(clinic.InstitutionName))

            {
                return false;
            }
            else
            {
                return true;
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
                        addClinicView.Close();
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
