using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_Core_3._1.Models;

namespace MVC_Core_3._1.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }
        [HttpGet]
        [Route("Home/AddRow") ]
        public IActionResult AddRow()
        {
            return View();
        }
        [HttpPost]
        [Route("Home/AddRow")]
        public IActionResult AddRow(Phone phone)
        {
            db.Phones.Add(phone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Home/DeleteRow")]
        public IActionResult DeleteRow()
        {
            return View();
        }
        [HttpPost]
        [Route("Home/DeleteRow")]
        public IActionResult DeleteRow(Phone phone)
        {
            var ph = db.Phones.FirstOrDefault(p => p.Id == phone.Id);
            db.Phones.Remove(ph);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Home/UpdateRow")]
        public IActionResult UpdateRow()
        {
            return View();
        }
        [HttpPost]
        [Route("Home/UpdateRow")]
        public IActionResult UpdateRow(Phone phone)
        {
            var id = phone.Id;
            var ph = db.Phones.FirstOrDefault(p => p.Id == id);
            if(phone.Name == null)
            {
                
            }
            else 
            {
                ph.Name = phone.Name;
            }
            if(phone.Company == null)
            {

            }
            else
            {
                 ph.Company = phone.Company;
            }
            if (phone.Price == 0)
            {

            }
            else
            {
                ph.Price = phone.Price;
            }
            db.Update(ph);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
