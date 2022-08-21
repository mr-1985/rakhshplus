using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.Services.Interfaces;
using MyShop.DataLayer.Entities;

namespace MyShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IAgentService _agentService;

        public HomeController(IAgentService agentService)
        {
            _agentService = agentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [BindProperty]
        public AgentDocument Document { get; set; }
        [HttpPost]
        public IActionResult OploadAgentDocuments(IFormFile imgMojavez, IFormFile imgSherkatname, IFormFile imgFishab, IFormFile imgFishtelephone,
            IFormFile imgAgahitaasis, IFormFile imgAkharintaaghirat, IFormFile imgFishgaz, IFormFile imgSanadNoe,
            IFormFile imgRoozname, IFormFile imgSardarforoshgah, IFormFile imgFishbargh)
        {
            _agentService.AddAgentDocument(Document, imgMojavez, imgAgahitaasis, imgRoozname, imgSherkatname,
                imgAkharintaaghirat, imgSardarforoshgah, imgFishab, imgFishgaz,
                imgFishbargh, imgFishtelephone, imgSanadNoe);

            return RedirectToPage("Index");
        }
    }
}
