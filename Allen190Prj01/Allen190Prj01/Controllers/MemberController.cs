using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Allen190Prj01.Models;
using System.Web.Security;
using System.Data.SqlClient;
using Dapper;

namespace Allen190Prj01.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        dbPrj01Entities1 db = new dbPrj01Entities1();
        private readonly string ConnStr = "Data Source=.;Initial Catalog=dbPrj01;Integrated Security=True";
        public ActionResult Index()
        {
            DBmanager dBmanager = new DBmanager();
            List<AdoMember> members = dBmanager.GetAdoMembers();
            ViewBag.members = members;
            return View("../Home/Index", "_LayoutMember", members);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Changestring()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Changestring(string txt)
        {

            string[] t = txt.Split(' ');
            string t0 = t[0];
            string t1 = t[1];
            string t2 = RevereseString(t1);
            string tt = t0 + " " + t1;
            string ctt = t0 + " " + t2;
            ViewBag.tt = tt;
            ViewBag.ctt = ctt;

            changestring chnew = new changestring();
            {
                chnew.fChar = tt;
                chnew.fNewChar = ctt;
                chnew.fUpDateTime = DateTime.Now;
            }
           

            string sql = @"Insert into tChangeString
            (fChar,fNewChar,fUpDateTime)
            values
            (@fChar,@fNewChar,@fUpDateTime)";

            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                con.Query<changestring>(sql,new{
                fChar= chnew.fChar,
                fNewChar= chnew.fNewChar,
                fUpDateTime= DateTime.Now
                });
              
            }

                return View();
           
        }
        public class changestring
        {
            public string fChar;
            public string fNewChar;
            public DateTime fUpDateTime;
        }
        public static string RevereseString(string str)
        {
            return string.Join("",str.Reverse());
        }
    }
}