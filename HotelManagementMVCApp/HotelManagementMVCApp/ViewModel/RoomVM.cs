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
        [Required(ErrorMessage ="Room number is required.")]
        public string roomNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "Room Image")]        
        public string roomImage { get; set; }

        [Display(Name = "Room Price*")]
        [Required(ErrorMessage = "Room price is required.")]
        [Range(500, 10000, ErrorMessage = "Room price should be equal or greater than {1}")]
        public int? roomPrice { get; set; }

        [Display(Name = "Booking Status*")]
        [Required(ErrorMessage = "Booking status is required.")]
        public int? bookingStatusId { get; set; }

        [Display(Name = "Room Type*")]
        [Required(ErrorMessage = "Room type is required.")]
        public int? roomTypeId { get; set; }

        [Display(Name = "Room Capacity*")]
        [Required(ErrorMessage = "Room capacity is required.")]
        [Range(1,8, ErrorMessage ="Room capacity should be equal or greater than {1}")]
        public int? roomCapacity { get; set; }

        [StringLength(50)]
        [Display(Name = "Room Description*")]
        [Required(ErrorMessage = "Room description is required.")]
        public string roomDescription { get; set; }

        [Display(Name = "Is Active")]       
        public bool? isActive { get; set; }

        public HttpPostedFileBase Image { get; set; }

        public List<SelectListItem> ListOfBookingStatus { get; set; }
        public List<SelectListItem> ListOfRoomType { get; set; }
    }
}