using AnApp.Client.Shared;
using AnApp.Shared.Data;
using AnApp.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace AnApp.Client.Services
{
    public class AgentService : IAgentService
    {
        private IHttpService _httpService;

        public AgentService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<PagedResult<Agent>> GetAgents(string? name, string page)
        {
            return await _httpService.Get<PagedResult<Agent>>("api/agent" + "?page=" + page + "&name=" + name);
        }

        public async Task<Agent> GetAgent(int id)
        {
            return await _httpService.Get<Agent>($"api/agent/{id}");
        }

        public async Task DeleteAgent(int id)
        {
            await _httpService.Delete($"api/agent/{id}");
        }

        public async Task AddAgent(Agent agent)
        {
            await _httpService.Post($"api/agent", agent);
        }

        public async Task UpdateAgent(Agent agent)
        {
            await _httpService.Put($"api/agent", agent);
        }
    }
}