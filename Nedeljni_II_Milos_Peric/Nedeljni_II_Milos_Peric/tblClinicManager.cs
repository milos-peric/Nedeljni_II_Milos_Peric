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
    
    public partial class tblClinicManager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblClinicManager()
        {
            this.tblClinicDoctors = new HashSet<tblClinicDoctor>();
        }
    
        public int ManagerID { get; set; }
        public Nullable<int> MaxNumberOfDoctors { get; set; }
        public Nullable<int> MinNumberOdRooms { get; set; }
        public Nullable<int> NumberOfOmissions { get; set; }
        public string ManagerFloor { get; set; }
        public Nullable<int> UserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClinicDoctor> tblClinicDoctors { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}