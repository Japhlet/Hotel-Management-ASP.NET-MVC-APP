namespace HotelManagementMVCApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        public int roomId { get; set; }

        [StringLength(10)]
        public string roomNumber { get; set; }

        [StringLength(50)]
        public string roomImage { get; set; }

        public int? roomPrice { get; set; }

        public int? bookingStatusId { get; set; }

        public int? roomTypeId { get; set; }

        public int? roomCapacity { get; set; }

        [StringLength(50)]
        public string roomDescription { get; set; }

        public bool? isActive { get; set; }

        public virtual BookingStatus BookingStatus { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}
