using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using MyShop.Core.Services.Interfaces;

namespace MyShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IAgentService _agentService;
        private IWebHostEnvironment _env;

        public HomeController(IAgentService agentService, IWebHostEnvironment env)
        {
            _agentService = agentService;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<IActionResult> Upload(IEnumerable<IFormFile> files, string term, int agentId)
        {


            long size = files.Sum(f => f.Length);
            if (size == 0)
            {
                return new JsonResult("failed");
            }
            if (size > 31457280)
            {
                return new JsonResult("maxfile");
            }
            foreach (var item in files)
            {
                var UploadsRootFolder = Path.Combine(_env.WebRootPath, "AgentDocuments");
                if (!Directory.Exists(UploadsRootFolder))
                    Directory.CreateDirectory(UploadsRootFolder);

                if (item != null)
                {

                    string FileExtension = Path.GetExtension(item.FileName);

                    var fileGuid = Guid.NewGuid().ToString();
                    string NewFileName = String.Concat(fileGuid, FileExtension);

                    if (term == "MojavezeKasbImage")
                    {
                        NewFileName = agentId + "-" + NewFileName;
                        _agentService.AddDocumentOfAgent(agentId, NewFileName,term);
                    }

                    if (term == "SherkatnameImage")
                    {
                        NewFileName = agentId + "-" + NewFileName;
                        _agentService.AddDocumentOfAgent(agentId, NewFileName, term);
                    }

                    if (term == "NewsPaperImage")
                    {
                        NewFileName = agentId + "-" + NewFileName;
                        _agentService.AddDocumentOfAgent(agentId, NewFileName, term);
                    }

                    if (term == "AgahiTaasisImage")
                    {
                        NewFileName = agentId + "-" + NewFileName;
                        _agentService.AddDocumentOfAgent(agentId, NewFileName, term);
                    }
                    if (term == "AkharinAgahiTaaghiratImage")
                    {
                        NewFileName = agentId + "-" + NewFileName;
                        _agentService.AddDocumentOfAgent(agentId, NewFileName, term);
                    }
                    if (term == "SarDarForoushgahImage")
                    {
                        NewFileName = agentId + "-" + NewFileName;
                        _agentService.AddDocumentOfAgent(agentId, NewFileName, term);
                    }
                    if (term == "FishAbImage")
                    {
                        NewFileName = agentId + "-" + NewFileName;
                        _agentService.AddDocumentOfAgent(agentId, NewFileName, term);
                    }
                    if (term == "FishGazImage")
                    {
                        NewFileName = agentId + "-" + NewFileName;
                        _agentService.AddDocumentOfAgent(agentId, NewFileName, term);
                    }
                    if (term == "FishBarghImage")
                    {
                        NewFileName = agentId + "-" + NewFileName;
                        _agentService.AddDocumentOfAgent(agentId, NewFileName, term);
                    }
                    if (term == "FishTelePhoneImage")
                    {
                        NewFileName = agentId + "-" + NewFileName;
                        _agentService.AddDocumentOfAgent(agentId, NewFileName, term);
                    }
                    if (term == "SanadNoeeMalekiatImage")
                    {
                        NewFileName = agentId + "-" + NewFileName;
                        _agentService.AddDocumentOfAgent(agentId, NewFileName, term);
                    }
                    
                    var path = Path.Combine(UploadsRootFolder, NewFileName);
                    using (var strem = new FileStream(path, FileMode.Create))
                    {
                        await item.CopyToAsync(strem);
                    }

                }
            }


            return new JsonResult("success");
        }


        

             [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<IActionResult> UploadOperativeDocument(IEnumerable<IFormFile> files, string term, int operativeId)
        {


            long size = files.Sum(f => f.Length);
            if (size == 0)
            {
                return new JsonResult("failed");
            }
            if (size > 31457280)
            {
                return new JsonResult("maxfile");
            }
            foreach (var item in files)
            {
                var UploadsRootFolder = Path.Combine(_env.WebRootPath, "OperativeDocuments");
                if (!Directory.Exists(UploadsRootFolder))
                    Directory.CreateDirectory(UploadsRootFolder);

                if (item != null)
                {

                    string FileExtension = Path.GetExtension(item.FileName);

                    var fileGuid = Guid.NewGuid().ToString();
                    string NewFileName = String.Concat(fileGuid, FileExtension);

                    if (term == "SarDarbForoushgahImage")
                    {
                        NewFileName = operativeId + "-" + NewFileName;
                        _agentService.AddOperativeDocumentOfAgent(operativeId, NewFileName, term);
                    }

                    var path = Path.Combine(UploadsRootFolder, NewFileName);
                    using (var strem = new FileStream(path, FileMode.Create))
                    {
                        await item.CopyToAsync(strem);
                    }

                }
            }
            return new JsonResult("success");
        }

        public IActionResult DeleteAgent(string[] agentId)
        {
            foreach (string id in agentId)
            {
                _agentService.DeleteAgent(Convert.ToInt32(id));
            }

            return Json(" Diesel Generators Successfully Deleted.");
        }

        
        public IActionResult DeleteOperative(string[] operativeId)
        {
            foreach (string id in operativeId)
            {
                _agentService.DeleteOperative(Convert.ToInt32(id));
            }

            return Json(" Diesel Generators Successfully Deleted.");
        }

        public IActionResult GetCityByOstanId(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید" , Value = ""}
            };
            list.AddRange(_agentService.GetCityByProvinceIDSelectList(id));
            return Json(new SelectList(list, "Value", "Text"));
        }

        ////public IActionResult GetAgentByAgentsId(int id)
        ////{
        ////    List<SelectListItem> list = new List<SelectListItem>()
        ////    {
        ////        new SelectListItem(){Text = "انتخاب کنید" , Value = ""}
        ////    };
        ////    list.AddRange(_agentService.GetCityByProvinceIDSelectList(id));
        ////    return Json(new SelectList(list, "Value", "Text"));
        ////}

        
    }
}
