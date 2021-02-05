namespace HotelManagementMVCApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentType")]
    public partial class PaymentType
    {
        public int paymentTypeId { get; set; }

        [Column("paymentType")]
        [StringLength(20)]
        public string paymentType1 { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
