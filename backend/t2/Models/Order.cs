namespace t2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.Orders")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int orderid { get; set; }

        public int? custid { get; set; }

        public int empid { get; set; }

        public DateTime orderdate { get; set; }

        public DateTime requireddate { get; set; }

        public DateTime? shippeddate { get; set; }

        public int shipperid { get; set; }

        [Column(TypeName = "money")]
        public decimal freight { get; set; }

        [Required]
        [StringLength(40)]
        public string shipname { get; set; }

        [Required]
        [StringLength(60)]
        public string shipaddress { get; set; }

        [Required]
        [StringLength(15)]
        public string shipcity { get; set; }

        [StringLength(15)]
        public string shipregion { get; set; }

        [StringLength(10)]
        public string shippostalcode { get; set; }

        [Required]
        [StringLength(15)]
        public string shipcountry { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Shipper Shipper { get; set; }
    }
}
