using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        private IHostingEnvironment _environment;

        public AgentService(MyShopContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
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

        

        public int AddDocumentOfAgent(int agentId, string fileName, string term)
        {
            var result = _context.AgentDocuments.FirstOrDefault(p => p.AgentId == agentId);
            if (result != null)
            {
                if (term == "MojavezeKasbImage")
                {
                    result.MojavezeKasbImage = fileName;
                }
                if (term == "SherkatnameImage")
                {
                    result.SherkatnameImage = fileName;
                }
                if (term == "NewsPaperImage")
                {
                    result.NewsPaperImage = fileName;
                }
                if (term == "AgahiTaasisImage")
                {
                    result.AgahiTaasisImage = fileName;
                }
                if (term == "AkharinAgahiTaaghiratImage")
                {
                    result.AkharinAgahiTaaghiratImage = fileName;
                }
                if (term == "SarDarForoushgahImage")
                {
                    result.SarDarForoushgahImage = fileName;
                }
                if (term == "FishAbImage")
                {
                    result.FishAbImage = fileName;
                }
                if (term == "FishGazImage")
                {
                    result.FishGazImage = fileName;
                }
                if (term == "FishBarghImage")
                {
                    result.FishBarghImage = fileName;
                }
                if (term == "FishTelePhoneImage")
                {
                    result.FishTelePhoneImage = fileName;
                }
                if (term == "SanadNoeeMalekiatImage")
                {
                    result.SanadNoeeMalekiatImage = fileName;
                }
                
                _context.AgentDocuments.Update(result);
                _context.SaveChanges();
                return 1;
            }
            else
            {
                AgentDocument document = new AgentDocument();
                document.AgentId = agentId;
                if (term == "MojavezeKasbImage")
                {
                    document.MojavezeKasbImage = fileName;
                }
                if (term == "SherkatnameImage")
                {
                    document.SherkatnameImage = fileName;
                }
                if (term == "NewsPaperImage")
                {
                    document.NewsPaperImage = fileName;
                }
                if (term == "AgahiTaasisImage")
                {
                    document.AgahiTaasisImage = fileName;
                }
                if (term == "AkharinAgahiTaaghiratImage")
                {
                    document.AkharinAgahiTaaghiratImage = fileName;
                }
                if (term == "SarDarForoushgahImage")
                {
                    document.SarDarForoushgahImage = fileName;
                }
                if (term == "FishAbImage")
                {
                    document.FishAbImage = fileName;
                }
                if (term == "FishGazImage")
                {
                    document.FishGazImage = fileName;
                }
                if (term == "FishBarghImage")
                {
                    document.FishBarghImage = fileName;
                }
                if (term == "FishTelePhoneImage")
                {
                    document.FishTelePhoneImage = fileName;
                }
                if (term == "SanadNoeeMalekiatImage")
                {
                    document.SanadNoeeMalekiatImage = fileName;
                }
                

                if (document.MojavezeKasbImage == null)
                {
                    document.MojavezeKasbImage = "defaultUpload.jpg";
                }
                if (document.SherkatnameImage == null)
                {
                    document.SherkatnameImage = "defaultUpload.jpg";
                }
                if (document.NewsPaperImage == null)
                {
                    document.NewsPaperImage = "defaultUpload.jpg";
                }
                if (document.AgahiTaasisImage == null)
                {
                    document.AgahiTaasisImage = "defaultUpload.jpg";
                }

                if (document.AkharinAgahiTaaghiratImage == null)
                {
                    document.AkharinAgahiTaaghiratImage = "defaultUpload.jpg";
                }
                if (document.SarDarForoushgahImage == null)
                {
                    document.SarDarForoushgahImage = "defaultUpload.jpg";
                }
                if (document.FishAbImage == null)
                {
                    document.FishAbImage = "defaultUpload.jpg";
                }

                if (document.FishGazImage == null)
                {
                    document.FishGazImage = "defaultUpload.jpg";
                }

                if (document.FishBarghImage == null)
                {
                    document.FishBarghImage = "defaultUpload.jpg";
                }

                if (document.FishTelePhoneImage == null)
                {
                    document.FishTelePhoneImage = "defaultUpload.jpg";
                }
                if (document.SanadNoeeMalekiatImage == null)
                {
                    document.SanadNoeeMalekiatImage = "defaultUpload.jpg";
                }
               


                _context.AgentDocuments.Add(document);
                _context.SaveChanges();
                return 1;
            }

        }

        public AgentDocument GetDocumentByAgentId(int agentId)
        {
            return _context.AgentDocuments.SingleOrDefault(a => a.AgentId == agentId);
        }
    }
}
