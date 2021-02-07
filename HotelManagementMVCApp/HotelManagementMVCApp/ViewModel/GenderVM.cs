using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagementMVCApp.ViewModel
{
    public class GenderVM
    {
        public int genderId { get; set; }

        [StringLength(10)]
        [Display(Name = "Gender:*")]
        [Required(ErrorMessage = "Gender is required.")]
        public string genderTypeName { get; set; }
    }
}