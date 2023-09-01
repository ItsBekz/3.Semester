using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseAndWindows.Controllers
{
    public class WindowController : Controller
    {
        // GET: WindowController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WindowController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WindowController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WindowController/Create
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

        // GET: WindowController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WindowController/Edit/5
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

        // GET: WindowController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WindowController/Delete/5
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
