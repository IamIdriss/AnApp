using AnApp.Shared.Models;
using AnApp.Shared.Data;
namespace AnApp.Server.Models
{
    public interface IAgentRepository
    {
        public interface IAgentRepository
        {
            PagedResult<Agent> GetAgents(string? name, int page);
            Task<Agent?> GetAgent(int Id);
            Task<Agent> AddAgent(Agent agent);
            Task<Agent?> UpdateAgent(Agent agent);
            Task<Agent?> DeleteAgent(int Id);
        }
    }
}
