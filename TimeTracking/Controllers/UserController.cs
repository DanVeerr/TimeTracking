using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimeTracking.Models;
using TimeTracking.Services;

namespace TimeTracking.Controllers
{
    public class UserController : Controller
    {
       
        private UsersContext db;
        private UserService userService;
        readonly IDiagnosticContext _diagnosticContext;
        public UserController(UsersContext context, UserService userService, IDiagnosticContext diagnosticContext)
        {
            _diagnosticContext = diagnosticContext ??
                throw new ArgumentNullException(nameof(diagnosticContext));
            db = context;
            this.userService = userService;
        }

        public bool CheckEmail(string Email, int Id)
        {
            
            if (db.Users.Where(c => c.Email == Email && c.Id != Id).Count() == 0)
            {

                return (true);
            }
            else
            {

                return (false);
            }

        }
        
        public IActionResult Create()
        {

            return View();
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await userService.Create(user);
                
                return RedirectToAction("Users");
            }

            return View(user);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                ViewBag.Email = user.Email;
                user.Email = "";
                db.Users.Update(user);
                await db.SaveChangesAsync();

                if (user == null)
                    return NotFound();

                return View(user);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            await userService.Edit(user);
            Log.Information("Edit");
            return RedirectToAction("Users");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);

                if (user != null)
                    return View(user);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                if (await userService.Delete(id))
                {

                    return RedirectToAction("Users");
                }
            }

            return NotFound();
        }

        public async Task<IActionResult> Users()
        {
            Log.Information("Main action");
            _diagnosticContext.Set("CatalogLoadTime", 1423);

            return View(await db.Users.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? code)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Code = code });
        }
    }
}
