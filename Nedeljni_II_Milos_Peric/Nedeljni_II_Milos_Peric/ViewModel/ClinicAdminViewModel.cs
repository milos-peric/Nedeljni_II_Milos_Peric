using Nedeljni_II_Milos_Peric.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_II_Milos_Peric.ViewModel
{
    class ClinicAdminViewModel : ViewModelBase
    {
        private ClinicAdminView clinicAdminView;

        public ClinicAdminViewModel(ClinicAdminView clinicAdminView, vwClinicAdmin clinicAdminInstance)
        {
            this.clinicAdminView = clinicAdminView;
            clinicAdmin = clinicAdminInstance;
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
    }
}
