using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTracking.Models;
using TimeTracking.ViewModels;

namespace TimeTracking.Controllers
{
    public class TrackingController : Controller
    {
        UsersContext db;
        private readonly ILogger<TrackingController> _logger;


        public TrackingController(ILogger<TrackingController> logger, UsersContext context)
        {
            _logger = logger;
            db = context;
        }
        public bool CheckDate(Report report)
        {
            if (report.Date.Subtract(DateTime.Now).TotalDays <= 0)
            {
                if (report.Date.Year == DateTime.Now.Year)
                {
                    return (true);
                }
                return (false);
            }
            else
            {
                return (false);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Create(int? ownerid)
        {
            List<User> users = await db.Users.ToListAsync();
            ViewBag.Users = await db.Users.Select(c => new UserModel { Id = c.Id, Surname = c.Surname }).ToListAsync();
            ViewBag.OwnerId = ownerid;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Report report)
        {
            if (ModelState.IsValid)
            {
                db.Reports.Add(report);
                await db.SaveChangesAsync();
                return RedirectToAction("Reports");
            }
            return NotFound();

        }
        public async Task<IActionResult> Details(int? id, int? UserId)
        {
            if (id != null)
            {
                Report report = await db.Reports.FirstOrDefaultAsync(p => p.Id == id);
                if (report != null)
                    return View(report);
                ViewBag.Owner = await db.Users.FirstOrDefaultAsync(p => p.Id == UserId);

            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id, int? UserId)
        {
            if (id != null)
            {
                List<User> users = await db.Users.ToListAsync();
                ViewBag.Users = await db.Users.Select(c => new UserModel { Id = c.Id, Surname = c.Surname }).ToListAsync();
                Report report = await db.Reports.FirstOrDefaultAsync(p => p.Id == id);
                ViewBag.Owner = await db.Users.FirstOrDefaultAsync(p => p.Id == UserId);
                if (report != null)
                    return View(report);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Report report)
        {
            db.Reports.Update(report);
            await db.SaveChangesAsync();
            return RedirectToAction("Reports");
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id, int? UserId)
        {
            if (id != null)
            {
                Report report = await db.Reports.FirstOrDefaultAsync(p => p.Id == id);
                if (UserId!=null)
                {
                    User us = await db.Users.FirstOrDefaultAsync(p => p.Id == UserId);
                    ViewBag.OwnerSurname = us.Surname;
                }
                if (report != null)
                    return View(report);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Report report = await db.Reports.FirstOrDefaultAsync(p => p.Id == id);
                if (report != null)
                {
                    db.Reports.Remove(report);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Reports");
                }
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Reports(int? UserId)
        {
            List<UserModel> userModel = await db.Users.Select(c => new UserModel { Id = c.Id, Surname = c.Surname }).ToListAsync();
            List<Report> reports = await db.Reports.ToListAsync();
            ReportsViewModel rvm = new ReportsViewModel { Users = userModel, Reports = reports };
            if (UserId != null && UserId > 0)
                rvm.Reports = reports.Where(p => p.OwnerId == UserId);
            
            ViewBag.Id = UserId;
            return View(rvm);
        }
    }
}
