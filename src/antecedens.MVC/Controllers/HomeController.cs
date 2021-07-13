using antecedens.Application.Interfaces;
using antecedens.Domain.Entities;
using antecedens_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace antecedens.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlockchainAppService _blockChainApp;

        public HomeController(ILogger<HomeController> logger, IBlockchainAppService blockchainApp)
        {
            _logger = logger;
            _blockChainApp = blockchainApp;
        }

        public IActionResult Index()
        {
            var chain = new Chain
            {
                Nome = "Paulo Henrique",
                CidadeNatal = "Caruaru/PE",
                CodigoCertidaoAntecedente = "AB728332P",
                CPF = "000.000.000-00",
                DataNascimento = DateTime.Now,
                DecisaoJudicialCondenatoria = "Nada Consta",
                Identidade = "0000000",
                Mae = "Eulina Cavalcanti",
                Pai = "Helio Cavalcanti",
                Nacionalidade = "Brasileira"
            };

            var block = new Block
            {
                AssociatedChain = chain,
                Difficulty = 4,
                Nonce = 0,
            };

            _blockChainApp.Add(block);

            return View();
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
