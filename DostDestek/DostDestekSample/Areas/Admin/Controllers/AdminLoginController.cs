﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DostDestek.Entity;

namespace DostDestekSample.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        public ActionResult AdminLogin()
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("AdminHome");
            }
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AdminLogin(Member member)
        {
            using (HayvanDestekEntities db = new HayvanDestekEntities())
            {
                var userDetails = db.Member.FirstOrDefault(t => t.Email == member.Email && t.Password == member.Password && t.RoleId == 1);
                if (userDetails == null)
                {
                    ViewBag.Mesaj = "E-mail veya sifre yanlis";
                    return RedirectToAction("AdminLogin", "AdminLogin");
                }
                else
                {
                    Session["User"] = userDetails;
                    return RedirectToAction("AdminHome", "AdminHome");
                }
            }
        }
    }
}