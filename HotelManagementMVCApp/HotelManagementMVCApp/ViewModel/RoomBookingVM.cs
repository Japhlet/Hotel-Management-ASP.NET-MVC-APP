using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementMVCApp.ViewModel
{
    public class RoomBookingVM
    {
        public int bookingId { get; set; }

        [Display(Name = "Customer*")]
        [Required(ErrorMessage = "Customer is required.")]
        public int? customerId { get; set; }
        
        [Display(Name = "Book From*")]
        [Required(ErrorMessage = "Booking start date is required.")]       
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime bookingFrom { get; set; }
        
        [Display(Name = "Book To*")]
        [Required(ErrorMessage = "Booking end date is required.")]        
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime bookingTo { get; set; }

        [Display(Name = "Assign Room*")]
        [Required(ErrorMessage = "Assign Room is required.")]
        public int? assignRoomId { get; set; }

        [Display(Name = "Number of Occupants*")]
        [Required(ErrorMessage = "Number of occupants is required.")]
        public int? numberOfOccupants { get; set; }

        [Display(Name = "Total Amount*")]        
        public int? totalAmount { get; set; }

        public bool? isDeleted { get; set; }

        public List<SelectListItem> ListOfCustomers { get; set; }
        public List<SelectListItem> ListOfAssignedRooms { get; set; }
    }
}