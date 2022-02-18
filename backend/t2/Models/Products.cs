namespace t2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production.Products")]
    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        public int productid { get; set; }

        [Required]
        [StringLength(40)]
        public string productname { get; set; }

        public int supplierid { get; set; }

        public int categoryid { get; set; }

        [Column(TypeName = "money")]
        public decimal unitprice { get; set; }

        public bool discontinued { get; set; }

        public virtual Categories Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual Suppliers Suppliers { get; set; }
    }
}
