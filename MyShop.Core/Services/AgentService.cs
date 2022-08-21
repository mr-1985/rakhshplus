using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyShop.Core.Generators;
using MyShop.Core.Services.Interfaces;
using MyShop.DataLayer.Context;
using MyShop.DataLayer.Entities;

namespace MyShop.Core.Services
{
    public class AgentService : IAgentService
    {
        private MyShopContext _context;

        public AgentService(MyShopContext context)
        {
            _context = context;
        }
        public int AddAgent(Agent agent)
        {
            agent.CreateDtae = DateTime.Now;
            _context.Add(agent);
            _context.SaveChanges();

            return agent.AgentId;
        }

        public List<Agent> GetAllGent()
        {
            return _context.Agents.ToList();
        }

        public int AddAgentDocument(AgentDocument document, IFormFile mojavezImg, IFormFile agahiTaasisImg
            , IFormFile rooznameImg, IFormFile sherkatnameImg, IFormFile akharinagahiImg, IFormFile sardarImg,
            IFormFile fishAbImg, IFormFile fishgazImg, IFormFile fishbarghImg, IFormFile fishtelephoneImg,
            IFormFile noemalekiyatImg)
        {
            document.CreateDate = DateTime.Now;
            document.MojavezeKasbImage = "media.jpg";
            document.AgahiTaasisImage = "media.jpg";
            document.NewsPaperImage = "media.jpg";
            document.SherkatnameImage = "media.jpg";
            document.AkharinAgahiTaaghiratImage = "media.jpg";
            document.SarDarForoushgahImage = "media.jpg";
            document.FishAbImage = "media.jpg";
            document.FishGazImage = "media.jpg";
            document.FishBarghImage = "media.jpg";
            document.SanadNoeeMalekiatImage = "media.jpg";



            if (mojavezImg != null)
            {
                document.MojavezeKasbImage = GeneratorName.GenrateUniqeCode() + Path.GetExtension(mojavezImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", document.MojavezeKasbImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    mojavezImg.CopyTo(stream);
                }

            }

            if (agahiTaasisImg != null)
            {
                document.AgahiTaasisImage = GeneratorName.GenrateUniqeCode() + Path.GetExtension(agahiTaasisImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", document.AgahiTaasisImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    agahiTaasisImg.CopyTo(stream);
                }

            }

            if (rooznameImg != null)
            {
                document.NewsPaperImage = GeneratorName.GenrateUniqeCode() + Path.GetExtension(rooznameImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", document.NewsPaperImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    rooznameImg.CopyTo(stream);
                }

            }

            if (sherkatnameImg != null)
            {
                document.SherkatnameImage = GeneratorName.GenrateUniqeCode() + Path.GetExtension(sherkatnameImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", document.SherkatnameImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    sherkatnameImg.CopyTo(stream);
                }

            }

            if (akharinagahiImg != null)
            {
                document.AkharinAgahiTaaghiratImage = GeneratorName.GenrateUniqeCode() + Path.GetExtension(akharinagahiImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", document.AkharinAgahiTaaghiratImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    akharinagahiImg.CopyTo(stream);
                }

            }

            if (sardarImg != null)
            {
                document.SarDarForoushgahImage = GeneratorName.GenrateUniqeCode() + Path.GetExtension(sardarImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", document.SarDarForoushgahImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    sardarImg.CopyTo(stream);
                }

            }

            if (fishAbImg != null)
            {
                document.FishAbImage = GeneratorName.GenrateUniqeCode() + Path.GetExtension(fishAbImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", document.FishAbImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    fishAbImg.CopyTo(stream);
                }

            }

            if (fishgazImg != null)
            {
                document.FishGazImage = GeneratorName.GenrateUniqeCode() + Path.GetExtension(fishgazImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", document.FishGazImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    fishgazImg.CopyTo(stream);
                }

            }

            if (fishbarghImg != null)
            {
                document.FishBarghImage = GeneratorName.GenrateUniqeCode() + Path.GetExtension(fishbarghImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", document.FishBarghImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    fishbarghImg.CopyTo(stream);
                }

            }

            if (noemalekiyatImg != null)
            {
                document.SanadNoeeMalekiatImage = GeneratorName.GenrateUniqeCode() + Path.GetExtension(noemalekiyatImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", document.SanadNoeeMalekiatImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    noemalekiyatImg.CopyTo(stream);
                }

            }

            if (fishtelephoneImg != null)
            {
                document.FishTelePhoneImage = GeneratorName.GenrateUniqeCode() + Path.GetExtension(fishtelephoneImg.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", document.FishTelePhoneImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    fishtelephoneImg.CopyTo(stream);
                }

            }

            _context.AgentDocuments.Add(document);
            _context.SaveChanges();

            return document.AgentDocumentId;
        }

        public AgentDocument GetDocumentByAgentId(int agentId)
        {
            return _context.AgentDocuments.SingleOrDefault(a => a.AgentId == agentId);
        }
    }
}
