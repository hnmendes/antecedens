using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace antecedens.MVC.Controllers
{
    public class BlockchainController : Controller
    {
        // GET: BlockchainController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BlockchainController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlockchainController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlockchainController/Create
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

        // GET: BlockchainController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlockchainController/Edit/5
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

        // GET: BlockchainController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlockchainController/Delete/5
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
