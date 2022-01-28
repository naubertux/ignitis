using Ignitis.DAL;
using Ignitis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignitis.Controllers
{
    public class HomeController : Controller
    {
        private readonly RegPozymiaiDAL _regPozDal = new RegPozymiaiDAL();

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Registracijos pozymiu lenteles eilutes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetRegistracijosPozymiai()
        {
            var eilutes = _regPozDal.GetRegPoz();
            return Json(eilutes, JsonRequestBehavior.AllowGet); 
        }

        /// <summary>
        /// Registracijos požymių išsaugojimas
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult StoreRegistracijosPozymiai(List<RegPozVM> regPozymiai)
        {
            _regPozDal.StoreRegPoz(regPozymiai);

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
        
    }
}