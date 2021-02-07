using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementMVCApp.ViewModel
{
    public class CustomerVM
    {
        public int customerId { get; set; }

        [StringLength(10)]
        [Display(Name = "First Name*")]
        [Required(ErrorMessage = "First Name is required.")]
        public string firstName { get; set; }

        [Display(Name = "Last Name*")]
        [Required(ErrorMessage = "Last Name is required.")]        
        public string lastName { get; set; }

        [Display(Name = "Phone Number*")]
        [Required(ErrorMessage = "Phone Number is required.")]
        public string phoneNumber { get; set; }

        [Display(Name = "Customer Address*")]
        [Required(ErrorMessage = "Customer Address is required.")]
        public string address { get; set; }

        [Display(Name = "Gender*")]
        [Required(ErrorMessage = "Gender is required.")]
        public int? genderId { get; set; }

        public List<SelectListItem> genderType { get; set; }
    }
}