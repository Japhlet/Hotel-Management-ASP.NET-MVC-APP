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

        [StringLength(20)]
        public string paymentTypeName { get; set; }

        public bool? isDeleted { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
