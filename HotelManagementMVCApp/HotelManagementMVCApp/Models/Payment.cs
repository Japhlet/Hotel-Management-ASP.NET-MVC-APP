namespace HotelManagementMVCApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        public int paymentId { get; set; }

        public int bookingId { get; set; }

        public int? paymentTypeId { get; set; }

        public int? paymentAmount { get; set; }

        public bool? isActive { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public virtual RoomBooking RoomBooking { get; set; }
    }
}
