//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LetPaintPictures.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BillHead
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillHead()
        {
            this.BillItems = new HashSet<BillItem>();
        }
    
        public int Id { get; set; }
        public int RequestHeadId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetPostOfficeBox { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Remarks { get; set; }
        public string Email { get; set; }
    
        public virtual BillCancellation BillCancellation { get; set; }
        public virtual RequestHead RequestHead { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillItem> BillItems { get; set; }
    }
}
