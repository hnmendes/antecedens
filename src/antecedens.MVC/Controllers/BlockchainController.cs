using antecedens.Application.Interfaces;
using antecedens.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace antecedens.MVC.Controllers
{
    public class BlockchainController : Controller
    {        
        private readonly IBlockchainAppService _blockChainApp;

        public BlockchainController(IBlockchainAppService blockchainApp)
        {
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

        // GET: BlockchainController/DownloadPDF    
        [HttpGet]
        public ActionResult DownloadPDF(string timeStamp)
        {
            string directory = System.IO.Directory.GetCurrentDirectory() + "\\wwwroot\\";
            
            var block = _blockChainApp.GetBlockByTimeStamp(timeStamp);

            string nameFile = "Antecedentes_Criminais-" + block.TimeStamp + ".pdf";            

            _blockChainApp.CreatePdfFile(block);
            
            HttpContext.Response.Headers.Add("Content-Disposition", "inline; filename=" + nameFile);

            var path = directory + nameFile;

            return File(path, "application/pdf");
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
