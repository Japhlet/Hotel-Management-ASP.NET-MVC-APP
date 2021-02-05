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
        [Display(Name = "Room Number*")]
        [Required]
        public string roomNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "Room Image*")]
        [Required]
        public string roomImage { get; set; }

        [Display(Name = "Room Price*")]
        [Required]
        public int? roomPrice { get; set; }

        [Display(Name = "Booking Status")]
        public int? bookingStatusId { get; set; }

        [Display(Name = "Room Type")]
        public int? roomTypeId { get; set; }

        [Display(Name = "Room Capacity")]
        public int? roomCapacity { get; set; }

        [StringLength(50)]
        [Display(Name = "Room Description")]        
        public string roomDescription { get; set; }

        [Display(Name = "Is Active")]       
        public bool? isActive { get; set; }

        public HttpPostedFileBase Image { get; set; }

        public List<SelectListItem> ListOfBookingStatus { get; set; }
        public List<SelectListItem> ListOfRoomType { get; set; }
    }
}