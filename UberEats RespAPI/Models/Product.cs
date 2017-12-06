//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UberEats_RespAPI.Models
{
    using System.Collections.Generic;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OnlineCarts = new HashSet<OnlineCart>();
        }
    
        public int Id { get; set; }
        public string itemName { get; set; }
        public double itemPrice { get; set; }
        public string description { get; set; }
        public string itemType { get; set; }
        public int userID { get; set; }
        public byte[] itemImage { get; set; }
        public bool archived { get; set;  }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OnlineCart> OnlineCarts { get; set; }
        public virtual Restaurant Restaurant { get; set; }

    }
}
