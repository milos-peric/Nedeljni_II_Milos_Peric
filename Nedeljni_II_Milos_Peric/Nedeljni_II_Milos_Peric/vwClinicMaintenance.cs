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
    
    public partial class vwClinicMaintenance
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string IDCardNumber { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ClinicMaintenaceID { get; set; }
        public Nullable<bool> CanChooseInvalidAccess { get; set; }
        public Nullable<bool> CanChooseClinicExpansionPermission { get; set; }
    }
}
