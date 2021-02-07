using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagementMVCApp.ViewModel
{
    public class CustomerDetailsVM
    {
        public int customerId { get; set; }
        
        public string firstName { get; set; }
        
        public string lastName { get; set; }
       
        public string phoneNumber { get; set; }
       
        public string address { get; set; }

        public string genderType { get; set; }
    }
}