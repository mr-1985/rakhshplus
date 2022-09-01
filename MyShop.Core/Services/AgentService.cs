using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var result = from agent in _context.Agents
                         join city in _context.City
                             on agent.City equals city.CityId.ToString()

                         join province in _context.Province
                             on agent.Ostan equals province.ProvinceId.ToString()
                         where agent.IsDelete == false
                         select (new Agent()
                         {
                             City = city.CityName,
                             Ostan = province.ProvinceName,
                             Address = agent.Address,
                             CreateDtae = agent.CreateDtae,
                             Email = agent.Email,
                             AgentId = agent.AgentId,
                             PostalCode = agent.PostalCode,
                             TelePhone = agent.TelePhone,
                             Fax = agent.Fax,
                             Name = agent.Name,
                             NoeMalekiat = agent.NoeMalekiat,
                             WebSite = agent.WebSite
                         });
            return result.ToList();
        }



        public int AddDocumentOfAgent(int agentId, string fileName, string term)
        {
            var result = _context.AgentDocuments.FirstOrDefault(p => p.AgentId == agentId);
            if (result != null)
            {
                if (term == "MojavezeKasbImage")
                {
                    if (result.MojavezeKasbImage != "media.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", result.MojavezeKasbImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.MojavezeKasbImage = fileName;
                }
                if (term == "SherkatnameImage")
                {
                    if (result.SherkatnameImage != "media.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", result.SherkatnameImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.SherkatnameImage = fileName;
                }
                if (term == "NewsPaperImage")
                {
                    if (result.NewsPaperImage != "media.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", result.NewsPaperImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.NewsPaperImage = fileName;
                }
                if (term == "AgahiTaasisImage")
                {
                    if (result.AgahiTaasisImage != "media.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", result.AgahiTaasisImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.AgahiTaasisImage = fileName;
                }
                if (term == "AkharinAgahiTaaghiratImage")
                {
                    if (result.AkharinAgahiTaaghiratImage != "media.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", result.AkharinAgahiTaaghiratImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.AkharinAgahiTaaghiratImage = fileName;
                }
                if (term == "SarDarForoushgahImage")
                {
                    if (result.SarDarForoushgahImage != "media.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", result.SarDarForoushgahImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.SarDarForoushgahImage = fileName;
                }
                if (term == "FishAbImage")
                {
                    if (result.FishAbImage != "media.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", result.FishAbImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.FishAbImage = fileName;
                }
                if (term == "FishGazImage")
                {
                    if (result.FishGazImage != "media.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", result.FishGazImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.FishGazImage = fileName;
                }
                if (term == "FishBarghImage")
                {
                    if (result.FishBarghImage != "media.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", result.FishBarghImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.FishBarghImage = fileName;
                }
                if (term == "FishTelePhoneImage")
                {
                    if (result.FishTelePhoneImage != "media.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", result.FishTelePhoneImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.FishTelePhoneImage = fileName;
                }
                if (term == "SanadNoeeMalekiatImage")
                {
                    if (result.SanadNoeeMalekiatImage != "media.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AgentDocuments", result.SanadNoeeMalekiatImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.SanadNoeeMalekiatImage = fileName;
                }
                result.CreateDate = DateTime.Now;
                ;
                _context.AgentDocuments.Update(result);
                _context.SaveChanges();
                return 1;
            }
            else
            {
                AgentDocument document = new AgentDocument();
                document.AgentId = agentId;
                document.CreateDate = DateTime.Now;

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
                    document.MojavezeKasbImage = "media.jpg";
                }
                if (document.SherkatnameImage == null)
                {
                    document.SherkatnameImage = "media.jpg";
                }
                if (document.NewsPaperImage == null)
                {
                    document.NewsPaperImage = "media.jpg";
                }
                if (document.AgahiTaasisImage == null)
                {
                    document.AgahiTaasisImage = "media.jpg";
                }

                if (document.AkharinAgahiTaaghiratImage == null)
                {
                    document.AkharinAgahiTaaghiratImage = "media.jpg";
                }
                if (document.SarDarForoushgahImage == null)
                {
                    document.SarDarForoushgahImage = "media.jpg";
                }
                if (document.FishAbImage == null)
                {
                    document.FishAbImage = "media.jpg";
                }

                if (document.FishGazImage == null)
                {
                    document.FishGazImage = "media.jpg";
                }

                if (document.FishBarghImage == null)
                {
                    document.FishBarghImage = "media.jpg";
                }

                if (document.FishTelePhoneImage == null)
                {
                    document.FishTelePhoneImage = "media.jpg";
                }
                if (document.SanadNoeeMalekiatImage == null)
                {
                    document.SanadNoeeMalekiatImage = "media.jpg";
                }



                _context.AgentDocuments.Add(document);
                _context.SaveChanges();
                return 1;
            }

        }

        public Agent GetAgentById(int agentId)
        {
            return _context.Agents.Find(agentId);
        }

        public AgentDocument GetDocumentByAgentId(int agentId)
        {
            return _context.AgentDocuments.SingleOrDefault(a => a.AgentId == agentId);
        }

        public void UpdateAgent(Agent agent)
        {
            agent.CreateDtae = DateTime.Now;
            _context.Update(agent);
            _context.SaveChanges();
        }

        public void DeleteAgent(int agentId)
        {
            var agent = _context.Agents.Find(agentId);
            agent.IsDelete = true;
            UpdateAgent(agent);
        }

        public List<Contract> GetAllAgentContracts()
        {
            return _context.Contracts.Where(c=>c.OperativeId==null).ToList();
        }

        public List<Contract> GetAllOperativeContracts()
        {
            return _context.Contracts.Where(c => c.AgentId == null).ToList();
        }

        public List<City> GetAllCity()
        {
            return _context.City.ToList();
        }

        public List<Province> GetAllProvince()
        {
            return _context.Province.ToList();
        }

        public List<SelectListItem> GetAllProvinceSelectList()
        {
            return _context.Province
                .Select(g => new SelectListItem()
                {
                    Text = g.ProvinceName,
                    Value = g.ProvinceId.ToString()
                }).ToList();
        }

        public List<City> GetCityByProvinceID(int ProvinceId)
        {
            return _context.City.Where(c => c.ProvinceId == ProvinceId).ToList();

        }

        public List<SelectListItem> GetCityByProvinceIDSelectList(int ProvinceId)
        {
            return _context.City.Where(p => p.ProvinceId == ProvinceId)
                .Select(g => new SelectListItem()
                {
                    Text = g.CityName,
                    Value = g.CityId.ToString()
                }).ToList();
        }

        public List<Operative> GetAllOperatives()
        {
            var result = from operative in _context.Operatives
                         join city in _context.City
                             on operative.City equals city.CityId.ToString()

                         join province in _context.Province
                             on operative.Ostan equals province.ProvinceId.ToString()
                         where operative.IsDelete == false
                         select (new Operative()
                         {
                             City = city.CityName,
                             Ostan = province.ProvinceName,
                             Address = operative.Address,
                             CreateDtae = operative.CreateDtae,
                             Email = operative.Email,
                             OperativeId = operative.OperativeId,
                             PostalCode = operative.PostalCode,
                             TelePhone = operative.TelePhone,
                             Fax = operative.Fax,
                             Name = operative.Name,
                             NoeMalekiat = operative.NoeMalekiat,
                             WebSite = operative.WebSite
                         });
            return result.ToList();
        }

        public int AddOperative(Operative operative)
        {
            operative.CreateDtae = DateTime.Now;

            _context.Add(operative);
            _context.SaveChanges();

            return operative.OperativeId;
        }

        public OperativeDocument GetOperativeDocumentByOperativeId(int operativeId)
        {
            return _context.OperativeDocuments.SingleOrDefault(a => a.OperativeId == operativeId);
        }

        public int AddOperativeDocumentOfAgent(int operativeId, string fileName, string term)
        {
            var result = _context.OperativeDocuments.FirstOrDefault(p => p.OperativeId == operativeId);
            if (result != null)
            {
                if (term == "SarDarbForoushgahImage")
                {
                    if (result.SarDarbForoushgahImage != "media.jpg")
                    {
                        string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/OperativeDocuments", result.SarDarbForoushgahImage);
                        if (File.Exists(deleteimagePath))
                        {
                            File.Delete(deleteimagePath);
                        }
                    }
                    result.SarDarbForoushgahImage = fileName;
                }



                result.CreateDate = DateTime.Now;
                _context.OperativeDocuments.Update(result);
                _context.SaveChanges();
                return 1;
            }
            else
            {
                OperativeDocument document = new OperativeDocument();
                document.OperativeId = operativeId;
                document.CreateDate = DateTime.Now;

                if (term == "SarDarbForoushgahImage")
                {
                    document.SarDarbForoushgahImage = fileName;
                }

                if (document.SarDarbForoushgahImage == null)
                {
                    document.SarDarbForoushgahImage = "media.jpg";
                }


                _context.OperativeDocuments.Add(document);
                _context.SaveChanges();
                return 1;
            }
        }

        public void DeleteOperative(int operativeId)
        {
            var operative = _context.Operatives.Find(operativeId);
            operative.IsDelete = true;
            UpdateOperative(operative);
        }

        public void UpdateOperative(Operative operative)
        {
            operative.CreateDtae = DateTime.Now;
            _context.Update(operative);
            _context.SaveChanges();
        }

        public Operative GetOperativeById(int operativeId)
        {
            return _context.Operatives.Find(operativeId);
        }

        public List<SelectListItem> GetAllAgentSelectList()
        {
            return _context.Agents
                .Select(g => new SelectListItem()
                {
                    Text = g.Name,
                    Value = g.AgentId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetAllOperativeSelectList()
        {
            return _context.Operatives
                .Select(g => new SelectListItem()
                {
                    Text = g.Name,
                    Value = g.OperativeId.ToString()
                }).ToList();
        }

        public int AddContract(Contract contract)
        {
            contract.CreateDate=DateTime.Now;
            _context.Add(contract);
            _context.SaveChanges();
            return contract.ContractId;

        }
    }
}
