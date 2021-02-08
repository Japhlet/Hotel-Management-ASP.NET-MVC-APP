using HotelManagementMVCApp.Models;
using HotelManagementMVCApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementMVCApp.Controllers
{
    public class RoomBookingController : Controller
    {
        private Db db;
        public RoomBookingController()
        {
            db = new Db();
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: RoomBooking
        public ActionResult Index()
        {
            RoomBookingVM roomBookingVM = new RoomBookingVM();

            roomBookingVM.ListOfCustomers = (from objCustomer in db.Customer
                                             where objCustomer.isDeleted == false
                                             select new SelectListItem()
                                          {
                                              Text = objCustomer.firstName +" "+ objCustomer.lastName,
                                              Value = objCustomer.customerId.ToString()
                                          }).ToList();

            roomBookingVM.ListOfAssignedRooms = (from objRoom in db.Room
                                                 where objRoom.bookingStatusId == 1
                                     select new SelectListItem()
                                     {
                                         Text = objRoom.roomNumber,
                                         Value = objRoom.roomId.ToString()
                                     }).ToList();
            return View(roomBookingVM);
        }
    }
}