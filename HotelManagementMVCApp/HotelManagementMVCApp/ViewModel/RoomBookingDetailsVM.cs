using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagementMVCApp.ViewModel
{
    public class RoomBookingDetailsVM
    {
        public int bookingId { get; set; }

        public string customer { get; set; }

        public DateTime bookingFrom { get; set; }

        public DateTime bookingTo { get; set; }

        public int numberOfDays { get; set; }

        public int roomPrice { get; set; }

        public string roomNumber { get; set; }

        public int numberOfOccupants { get; set; }

        public int totalAmount { get; set; }

        public bool isDeleted { get; set; }
    }
}