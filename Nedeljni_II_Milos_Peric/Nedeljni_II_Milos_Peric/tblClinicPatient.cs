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
    
    public partial class tblClinicPatient
    {
        public int PatientID { get; set; }
        public string HealthCardNumber { get; set; }
        public Nullable<System.DateTime> HealthAssuranceExpiryDate { get; set; }
        public string DoctorUniqueNumber { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual tblClinicDoctor tblClinicDoctor { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}