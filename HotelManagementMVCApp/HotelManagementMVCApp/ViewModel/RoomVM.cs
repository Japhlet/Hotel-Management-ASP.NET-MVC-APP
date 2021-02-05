using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementMVCApp.ViewModel
{
    public class RoomVM
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

        public HttpPostedFileBase Image { get; set; }

        public List<SelectListItem> ListOfBookingStatus { get; set; }
        public List<SelectListItem> ListOfRoomType { get; set; }
    }
}