using AnApp.Shared.Data;
using AnApp.Shared.Models;

namespace AnApp.Client.Services
{
    public interface IAgentService
    {
        Task<PagedResult<Agent>> GetAgents(string? name, string page);
        Task<Agent> GetAgent(int id);

        Task DeleteAgent(int id);

        Task AddAgent(Agent person);

        Task UpdateAgent(Agent person);
    }
}

