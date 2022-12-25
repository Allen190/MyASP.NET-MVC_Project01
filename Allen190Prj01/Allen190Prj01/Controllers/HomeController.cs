using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Allen190Prj01.Models;

namespace Allen190Prj01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBmanager dBmanager = new DBmanager();
            List<AdoMember> members = dBmanager.GetAdoMembers();
            ViewBag.members = members;
            return View();
        }

        public ActionResult CreateMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMember(AdoMember member)
        {
            DBmanager dBmanager = new DBmanager();
            try
            {
                dBmanager.NewMember(member);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return RedirectToAction("Index");
        }

    }
}