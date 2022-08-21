using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyShop.DataLayer.Entities;

namespace MyShop.Core.Services.Interfaces
{
    public interface IAgentService
    {
        int AddAgent(Agent agent);
        List<Agent> GetAllGent();
        int AddAgentDocument( AgentDocument document,IFormFile mojavezImg,IFormFile agahiTaasisImg
        ,IFormFile rooznameImg,IFormFile sherkatnameImg,IFormFile akharinagahiImg,IFormFile sardarImg,
        IFormFile fishAbImg,IFormFile fishgazImg,IFormFile fishbarghImg,IFormFile fishtelephoneImg,
        IFormFile noemalekiyatImg);

        AgentDocument GetDocumentByAgentId(int agentId);
    }
}
