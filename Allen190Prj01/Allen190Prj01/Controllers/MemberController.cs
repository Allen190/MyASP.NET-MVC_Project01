using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Allen190Prj01.Models;
using System.Web.Security;


namespace Allen190Prj01.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
    dbPrj01Entities1 db = new dbPrj01Entities1();
        public ActionResult Index()
        {
            DBmanager dBmanager = new DBmanager();
            List<AdoMember> members = dBmanager.GetAdoMembers();
            ViewBag.members = members;
            return View("../Home/Index","_LayoutMember",members);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Home");
        }

        public ActionResult Changestring()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Changestring(string txt)
        {
            
            string [] t= txt.Split(' ');
            string t0 = t[0];
            string t1 = t[1];
            string t2 = RevereseString(t1);
            string tt = t0+" "+t1;
            string ctt = t0+" " +t2;
            ViewBag.tt = tt;
            ViewBag.ctt = ctt;

            //tChangeString chnew = new tChangeString();
            //chnew.fChar = t1;
            //chnew.fNewChar = t2;
            //chnew.fUpDateTime=DateTime.Now;
            //List<tChangeString> list= new List<tChangeString>();
            //list.Add(chnew);
            //db.SaveChanges();
            return View();
        }
        public static string RevereseString(string str)
        {
            return string.Join("",str.Reverse());
        }
    }
}