using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Allen190Prj01.Models;
using Microsoft.Ajax.Utilities;

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
        public ActionResult CreateMember(tMember member)
        {
            dbPrj01Entities1 db = new dbPrj01Entities1();
            if (ModelState.IsValid == false)
            { return View(); }
            var mm = db.tMember.Where(m => m.MemAccount == member.MemAccount).FirstOrDefault();
            if (mm == null)
            {
                db.tMember.Add(member);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            //Win = "此帳號已經有人使用，請重新註冊";
            return Content("<script>alert('此帳號已經有人使用，請重新註冊');history.go(-1);</script>");

        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string MemAccount, string MemPassword)
        {
             dbPrj01Entities1 db = new dbPrj01Entities1();
            var Account = MemAccount;
            var Password = MemPassword;
            var member = db.Database.SqlQuery<string>("Select MemAccount from tMember where MemAccount=@MemAccount and MemPassword=@MemPassword", new SqlParameter("@MemAccount", Account), new SqlParameter("@MemPassword", Password)).FirstOrDefault();
            if (member == null)
            {
                ViewBag.Message = "帳密錯誤，請確認!";
                return View();
            };
            Session["Welcom"] = member + "歡迎觀臨";
            FormsAuthentication.RedirectFromLoginPage(MemAccount, true);
            return RedirectToAction("Index", "Member");
        }
    }
}