namespace HotelManagementMVCApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoomBooking")]
    public partial class RoomBooking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoomBooking()
        {
            Payment = new HashSet<Payment>();
        }

        [Key]
        public int bookingId { get; set; }

        public int? customerId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? bookingFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? bookingTo { get; set; }

        public int? assignRoomId { get; set; }

        public int? numberOfOccupants { get; set; }

        public int? totalAmount { get; set; }

        public bool? isDeleted { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
