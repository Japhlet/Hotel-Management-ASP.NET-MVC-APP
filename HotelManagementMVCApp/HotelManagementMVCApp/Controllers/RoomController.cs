using HotelManagementMVCApp.Models;
using HotelManagementMVCApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementMVCApp.Controllers
{
    public class RoomController : Controller
    {
        private Db db;
        public RoomController()
        {
            db = new Db();
        }

        // GET: Room
        public ActionResult Index()
        {
            RoomVM roomVM = new RoomVM();

            roomVM.ListOfBookingStatus = (from obj in db.BookingStatus
                                          select new SelectListItem()
                                          {
                                              Text = obj.bookingStatusName,
                                              Value = obj.bookingStatusId.ToString()
                                          }).ToList();

            roomVM.ListOfRoomType = (from obj in db.RoomType
                                     select new SelectListItem()
                                     {
                                         Text = obj.roomTypeName,
                                         Value = obj.roomTypeId.ToString()
                                     }).ToList();
            return View(roomVM);
        }
    }
}