using HotelManagementMVCApp.Models;
using HotelManagementMVCApp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
            db.Configuration.ProxyCreationEnabled = false;
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

        [HttpPost]
        public ActionResult Index(RoomVM roomVM)
        {
            string imageUniqueName = String.Empty;
            string actualImageName = String.Empty;
            string message = String.Empty;

            if (roomVM.roomId == 0)
            {
                imageUniqueName = Guid.NewGuid().ToString();
                actualImageName = imageUniqueName + Path.GetExtension(roomVM.Image.FileName);
                roomVM.Image.SaveAs(Server.MapPath("~/RoomImages/" + actualImageName));

                Room room = new Room()
                {
                    roomNumber = roomVM.roomNumber,
                    roomPrice = roomVM.roomPrice,
                    roomDescription = roomVM.roomDescription,
                    roomCapacity = roomVM.roomCapacity,
                    roomTypeId = roomVM.roomTypeId,
                    isActive = true,
                    bookingStatusId = roomVM.bookingStatusId,
                    roomImage = actualImageName
                };

                db.Room.Add(room);
                message = "Room saved successfully.";
            } else
            {
                Room roomToEdit = db.Room.Single(m => m.roomId == roomVM.roomId);

                if (roomVM.Image != null)
                {
                    imageUniqueName = Guid.NewGuid().ToString();
                    actualImageName = imageUniqueName + Path.GetExtension(roomVM.Image.FileName);
                    roomVM.Image.SaveAs(Server.MapPath("~/RoomImages/" + actualImageName));
                    roomToEdit.roomImage = actualImageName;
                }

                roomToEdit.roomNumber = roomVM.roomNumber;
                roomToEdit.roomPrice = roomVM.roomPrice;
                roomToEdit.roomDescription = roomVM.roomDescription;
                roomToEdit.roomCapacity = roomVM.roomCapacity;
                roomToEdit.roomTypeId = roomVM.roomTypeId;
                roomToEdit.isActive = true;
                roomToEdit.bookingStatusId = roomVM.bookingStatusId;
                
                message = "Room updated successfully.";
            }

            db.SaveChanges();

            return Json(new { message = message, success = true }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetAllRooms()
        {
            IEnumerable<RoomDetailsVM> ListOfRoomDetailsVM =
                (from objRoom in db.Room
                 join objBooking in db.BookingStatus on objRoom.bookingStatusId equals objBooking.bookingStatusId
                 join objRoomType in db.RoomType on objRoom.roomTypeId equals objRoomType.roomTypeId
                 select new RoomDetailsVM()
                 {
                     roomNumber = objRoom.roomNumber,
                     roomPrice = (int) objRoom.roomPrice,
                     roomCapacity = (int) objRoom.roomCapacity,
                     roomDescription = objRoom.roomDescription,
                     bookingStatus = objBooking.bookingStatusName,
                     roomType = objRoomType.roomTypeName,
                     roomImage = objRoom.roomImage,
                     roomId = objRoom.roomId
                 }).ToList();
            return PartialView("_RoomDetailsPartial", ListOfRoomDetailsVM);
        }

        [HttpGet]
        public JsonResult EditRoomDetails(int roomId)
        {
            var result = db.Room.Single(m => m.roomId == roomId); 

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}