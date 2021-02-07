using HotelManagementMVCApp.Models;
using HotelManagementMVCApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementMVCApp.Controllers
{
    public class GenderController : Controller
    {
        private Db db;
        public GenderController()
        {
            db = new Db();
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: Gender
        public ActionResult Index()
        {
            GenderVM genderVM = new GenderVM();

            return View(genderVM);
        }

        [HttpPost]
        public ActionResult Index(GenderVM genderVM)
        {
            string message = String.Empty;

            if (genderVM.genderId == 0)
            {
                Gender gender = new Gender()
                {
                    genderTypeName = genderVM.genderTypeName,                    
                    isDeleted = false
                };

                db.Gender.Add(gender);
                message = "Gender Type saved successfully.";
            }
            else
            {
                Gender genderToEdit = db.Gender.Single(m => m.genderId == genderVM.genderId);

                genderToEdit.genderTypeName = genderVM.genderTypeName;                
                genderToEdit.isDeleted = false;

                message = "Gender Type updated successfully.";
            }

            db.SaveChanges();

            return Json(new { message = message, success = true }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetAllGenderTypes()
        {
            IEnumerable<GenderDetailsVM> ListOfGenderDetailsVM =
                (from objGender in db.Gender                 
                 where objGender.isDeleted == false
                 select new GenderDetailsVM()
                 {                     
                     genderType = objGender.genderTypeName,
                     genderId = objGender.genderId
                 }).ToList();
            return PartialView("_GenderDetailsPartial", ListOfGenderDetailsVM);
        }

        [HttpGet]
        public JsonResult EditGenderDetails(int genderId)
        {
            var result = db.Gender.Single(m => m.genderId == genderId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DeleteGenderDetails(int genderId)
        {
            string msg = String.Empty;

            Gender gender = db.Gender.Single(m => m.genderId == genderId);
            gender.isDeleted = true;

            db.SaveChanges();
            msg = "Record successfully deleted.";

            return Json(new { message = msg, success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}