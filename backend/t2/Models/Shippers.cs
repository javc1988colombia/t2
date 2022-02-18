namespace t2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.Shippers")]
    public partial class Shippers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shippers()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int shipperid { get; set; }

        [Required]
        [StringLength(40)]
        public string companyname { get; set; }

        [Required]
        [StringLength(24)]
        public string phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
