namespace t2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.Customers")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int custid { get; set; }

        [Required]
        [StringLength(40)]
        public string companyname { get; set; }

        [Required]
        [StringLength(30)]
        public string contactname { get; set; }

        [Required]
        [StringLength(30)]
        public string contacttitle { get; set; }

        [Required]
        [StringLength(60)]
        public string address { get; set; }

        [Required]
        [StringLength(15)]
        public string city { get; set; }

        [StringLength(15)]
        public string region { get; set; }

        [StringLength(10)]
        public string postalcode { get; set; }

        [Required]
        [StringLength(15)]
        public string country { get; set; }

        [Required]
        [StringLength(24)]
        public string phone { get; set; }

        [StringLength(24)]
        public string fax { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
