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
        
        int AddDocumentOfAgent(int agentId, string fileName, string term);

        AgentDocument GetDocumentByAgentId(int agentId);
    }
}
