using AnApp.Server.Authorization;
using AnApp.Server.Models;
using AnApp.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnApp.Server.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AgentController : ControllerBase
    {
        private readonly IAgentRepository _agentRepository;

        public AgentController(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        /// <summary>
        /// Returns a list of paginated Agents with a default page size of 5.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetAgents([FromQuery] string? name, int page)
        {
            return Ok(_agentRepository.GetAgents(name, page));
        }

        /// <summary>
        /// Gets a specific Agent by Id.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAgent(int id)
        {
            return Ok(await _agentRepository.GetAgent(id));
        }

        /// <summary>
        /// Creates a Agent with child department.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddAgent(Agent agent)
        {
            return Ok(await _agentRepository.AddAgent(agent));
        }

        /// <summary>
        /// Updates a Agent with a specific Id.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateAgent(Agent agent)
        {
            return Ok(await _agentRepository.UpdateAgent(agent));
        }

        /// <summary>
        /// Deletes a Agent with a specific Id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAgent(int id)
        {
            return Ok(await _agentRepository.DeleteAgent(id));
        }
    }
}