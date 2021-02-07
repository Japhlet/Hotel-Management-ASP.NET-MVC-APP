namespace HotelManagementMVCApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            RoomBooking = new HashSet<RoomBooking>();
        }

        public int customerId { get; set; }

        [StringLength(20)]
        public string firstName { get; set; }

        [StringLength(20)]
        public string lastName { get; set; }

        [StringLength(15)]
        public string phoneNumber { get; set; }

        [StringLength(20)]
        public string address { get; set; }

        public int? genderId { get; set; }

        public bool? isDeleted { get; set; }

        public virtual Gender Gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoomBooking> RoomBooking { get; set; }
    }
}
