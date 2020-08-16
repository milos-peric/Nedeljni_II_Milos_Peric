//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nedeljni_II_Milos_Peric
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblClinicDoctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblClinicDoctor()
        {
            this.tblClinicPatients = new HashSet<tblClinicPatient>();
        }
    
        public int DoctorID { get; set; }
        public string UniqueNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Sector { get; set; }
        public string DoctorShift { get; set; }
        public Nullable<bool> RecievesPatients { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public Nullable<int> UserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClinicPatient> tblClinicPatients { get; set; }
        public virtual tblClinicManager tblClinicManager { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}