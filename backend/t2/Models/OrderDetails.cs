namespace t2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.OrderDetails")]
    public partial class OrderDetails
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int orderid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int productid { get; set; }

        [Column(TypeName = "money")]
        public decimal unitprice { get; set; }

        public short qty { get; set; }

        [Column(TypeName = "numeric")]
        public decimal discount { get; set; }

        public virtual Products Products { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
