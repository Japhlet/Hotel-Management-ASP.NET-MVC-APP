using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagementMVCApp.ViewModel
{
    public class RoomDetailsVM
    {
        public int roomId { get; set; }

        public string roomNumber { get; set; }

        public string roomImage { get; set; }

        public int roomPrice { get; set; }

        public String bookingStatus { get; set; }

        public String roomType { get; set; }

        public int roomCapacity { get; set; }

        public string roomDescription { get; set; }
    }
}