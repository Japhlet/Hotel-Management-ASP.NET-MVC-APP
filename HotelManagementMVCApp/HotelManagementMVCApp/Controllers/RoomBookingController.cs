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
            roomBookingVM.bookingFrom = DateTime.Now;
            roomBookingVM.bookingTo = DateTime.Now.AddDays(1);
            return View(roomBookingVM);
        }

        [HttpPost]
        public ActionResult Index(RoomBookingVM roomBookingVM)
        {            
            string message = String.Empty;

            int numberOfDays = Convert.ToInt32((roomBookingVM.bookingTo - roomBookingVM.bookingFrom).TotalDays);
            Room objRoom = db.Room.Single(m => m.roomId == roomBookingVM.assignRoomId);
            int roomPrice = (int) objRoom.roomPrice;
            int roomTotalAmount = roomPrice * numberOfDays;            
            
            if (roomBookingVM.bookingId == 0)
            {   
                RoomBooking roomBooking = new RoomBooking()
                {
                    customerId = roomBookingVM.customerId,
                    bookingFrom = roomBookingVM.bookingFrom,
                    bookingTo = roomBookingVM.bookingTo,
                    assignRoomId = roomBookingVM.assignRoomId,
                    numberOfOccupants = roomBookingVM.numberOfOccupants,
                    totalAmount = roomTotalAmount,
                    isDeleted = false
                };

                db.RoomBooking.Add(roomBooking);
                message = "Customer room booking saved successfully.";
            }
            else
            {
                RoomBooking roomBookingToEdit = db.RoomBooking.Single(m => m.bookingId == roomBookingVM.bookingId);

                roomBookingToEdit.customerId = roomBookingVM.customerId;
                roomBookingToEdit.bookingFrom = roomBookingVM.bookingFrom;
                roomBookingToEdit.bookingTo = roomBookingVM.bookingTo;
                roomBookingToEdit.assignRoomId = roomBookingVM.assignRoomId;
                roomBookingToEdit.numberOfOccupants = roomBookingVM.numberOfOccupants;
                roomBookingToEdit.totalAmount = roomBookingVM.totalAmount;
                roomBookingToEdit.isDeleted = false;                

                message = "Customer room booking updated successfully.";
            }

            db.SaveChanges();

            objRoom.bookingStatusId = 3;
            db.SaveChanges();

            return Json(new { message = message, success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}