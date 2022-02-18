namespace t2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.Employees")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Employees1 = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }

        [Key]
        public int empid { get; set; }

        [Required]
        [StringLength(20)]
        public string lastname { get; set; }

        [Required]
        [StringLength(10)]
        public string firstname { get; set; }

        [Required]
        [StringLength(30)]
        public string title { get; set; }

        [Required]
        [StringLength(25)]
        public string titleofcourtesy { get; set; }

        public DateTime birthdate { get; set; }

        public DateTime hiredate { get; set; }

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

        public int? mgrid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees1 { get; set; }

        public virtual Employee Employee1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
