using antecedens.Application.Interfaces;
using antecedens.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace antecedens.MVC.Controllers
{
    public class BlockchainController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IBlockchainAppService _blockChainApp;

        public BlockchainController(ILogger<HomeController> logger, IBlockchainAppService blockchainApp)
        {
            _logger = logger;
            _blockChainApp = blockchainApp;
        }

        // GET: BlockchainController
        public ActionResult Chains()
        {
            var blocks = _blockChainApp.GetAll();

            return View(blocks);
        }

        // GET: BlockchainController
        public ActionResult Blocks()
        {
            var blocks = _blockChainApp.GetAll();

            return View(blocks);
        }        

        // GET: BlockchainController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlockchainController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chain chain)
        {
            try
            {
                _blockChainApp.Add(chain);

                return RedirectToAction("Blocks");
            }
            catch
            {
                return View();
            }
        }
    }
}
