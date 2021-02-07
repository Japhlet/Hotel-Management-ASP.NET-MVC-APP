using HotelManagementMVCApp.Models;
using HotelManagementMVCApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementMVCApp.Controllers
{
    public class CustomerController : Controller
    {
        private Db db;
        public CustomerController()
        {
            db = new Db();
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: Customer
        public ActionResult Index()
        {
            CustomerVM customerVM = new CustomerVM();

            customerVM.genderType = (from obj in db.Gender
                                          select new SelectListItem()
                                          {
                                              Text = obj.genderTypeName,
                                              Value = obj.genderId.ToString()
                                          }).ToList();            
            return View(customerVM);
        }
    }
}