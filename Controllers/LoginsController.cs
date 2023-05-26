using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tourist_Platform.Models;
using Tourist_Platform.Services;

namespace Tourist_Platform.Controllers
{
    public class LoginsController : Controller
    {
        private readonly TouristDbContext _context;
        private ILoginServices services;

        public LoginsController(TouristDbContext context, ILoginServices services)
        {
            _context = context;
            this.services = services;
        }


        // GET: LoginsController
        public ActionResult Index()
        {
            ViewBag.session = HttpContext.Session.GetString("accNo");
            if (HttpContext.Session.GetString("accNo") == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> checkLogin(string accNo, string pinCode)
        {
            Models.AdminLogic admin = services.checkAdminLogin(accNo, pinCode);
            Models.UserAccount user = services.checkUserAccount(accNo, pinCode);
            if(admin != null)
            {
                HttpContext.Session.SetString("accNo", accNo);
                if (admin.Password.Equals(pinCode))
                {
                    return View("~/Views/AdminLogics/Index.cshtml");
                }
            }
            else if (user!=null){
                HttpContext.Session.SetString("accNo", accNo);
                if (user.Password.Equals(pinCode))
                {
                    return View("~/Views/web/signup.cshtml");
                }
            }


            return View();

        }
        
        //[ActionName("Login")]
        public IActionResult checkAdminLogin(string accNo, string pinCode)
        {
            try
            {
                Models.AdminLogic acc = services.checkAdminLogin(accNo, pinCode);
                if (acc != null)
                {
                    HttpContext.Session.SetString("accNo", accNo);
                    if (acc.Password.Equals(pinCode))
                    {
                        return RedirectToAction("Index");
                    }
                   /* else
                    {
                        return RedirectToAction("NotAdmin", acc);
                    }*/
                }
               /* else
                {
                    ViewBag.msg = "Invalid Country!!!";
                }*/
            }
            catch (Exception e)
            {

                ViewBag.message = e.Message;
            }
            return View();
        }
        public IActionResult checkUserAccount(string accNo, string pinCode)
        {
            try
            {
                Models.UserAccount acc = services.checkUserAccount(accNo, pinCode);
                if (acc != null)
                {
                    HttpContext.Session.SetString("accNo", accNo);
                    if (acc.Password.Equals(pinCode))
                    {
                        return RedirectToAction("Index");
                    }
                    /* else
                     {
                         return RedirectToAction("NotAdmin", acc);
                     }*/
                }
                /* else
                 {
                     ViewBag.msg = "Invalid Country!!!";
                 }*/
            }
            catch (Exception e)
            {

                ViewBag.message = e.Message;
            }
            return View();
        }
        // GET: Accounts/Details/5
        // GET: LoginsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
