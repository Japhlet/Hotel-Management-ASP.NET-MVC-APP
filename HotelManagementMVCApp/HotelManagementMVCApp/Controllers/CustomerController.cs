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

        [HttpPost]
        public ActionResult Index(CustomerVM customerVM)
        {
            string message = String.Empty;

            if (customerVM.customerId == 0)
            {
                Customer customer = new Customer()
                {
                    firstName = customerVM.firstName,
                    lastName = customerVM.lastName,
                    phoneNumber = customerVM.phoneNumber,
                    address = customerVM.address,
                    genderId = customerVM.genderId                    
                };

                db.Customer.Add(customer);
                message = "Customer saved successfully.";
            }
            else
            {
                Customer customerToEdit = db.Customer.Single(m => m.customerId == customerVM.customerId);

                customerToEdit.firstName = customerVM.firstName;
                customerToEdit.lastName = customerVM.lastName;
                customerToEdit.phoneNumber = customerVM.phoneNumber;
                customerToEdit.address = customerVM.address;
                customerToEdit.genderId = customerVM.genderId;

                message = "Customer updated successfully.";
            }

            db.SaveChanges();

            return Json(new { message = message, success = true }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetAllCustomers()
        {
            IEnumerable<CustomerDetailsVM> ListOfCustomerDetailsVM =
                (from objCustomer in db.Customer
                 join objGender in db.Gender on objCustomer.genderId equals objGender.genderId                 
                 select new CustomerDetailsVM()
                 {
                     firstName = objCustomer.firstName,
                     lastName = objCustomer.lastName,
                     phoneNumber = objCustomer.phoneNumber,
                     address = objCustomer.address,
                     genderType = objGender.genderTypeName,                     
                     customerId = objCustomer.customerId
                 }).ToList();
            return PartialView("_CustomerDetailsPartial", ListOfCustomerDetailsVM);
        }

        [HttpGet]
        public JsonResult EditCustomerDetails(int customerId)
        {
            var result = db.Customer.Single(m => m.customerId == customerId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}