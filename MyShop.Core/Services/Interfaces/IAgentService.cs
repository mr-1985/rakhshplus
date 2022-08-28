using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.DataLayer.Entities;

namespace MyShop.Core.Services.Interfaces
{
    public interface IAgentService
    {
        int AddAgent(Agent agent);
        List<Agent> GetAllGent();
        
        int AddDocumentOfAgent(int agentId, string fileName, string term);
        Agent GetAgentById(int agentId);
        AgentDocument GetDocumentByAgentId(int agentId);
        void UpdateAgent(Agent agent);
        void DeleteAgent(int agentId);
        List<Contract> GetAllAgentContracts();
        List<Contract> GetAllOperativeContracts();

        #region Province

        List<City> GetAllCity();
        List<Province> GetAllProvince();
        List<SelectListItem> GetAllProvinceSelectList();
        List<City> GetCityByProvinceID(int ProvinceId);
        List<SelectListItem> GetCityByProvinceIDSelectList(int ProvinceId);

        #endregion

        #region Operative

        List<Operative> GetAllOperatives();
        int AddOperative(Operative operative);
        OperativeDocument GetOperativeDocumentByOperativeId(int operativeId);
        int AddOperativeDocumentOfAgent(int operativeId, string fileName, string term);
        void DeleteOperative(int operativeId);
        void UpdateOperative(Operative operative);
        Operative GetOperativeById(int operativeId);

        #endregion

        #region Contract

        List<SelectListItem> GetAllAgentSelectList();
        List<SelectListItem> GetAllOperativeSelectList();

        int AddContract(Contract contract);
        
        #endregion
    }
}
