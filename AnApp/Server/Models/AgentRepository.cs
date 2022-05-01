using AnApp.Shared.Models;
using AnApp.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace AnApp.Server.Models
{
    public class AgentRepository : IAgentRepository
    {
        private readonly AppDbContext _appDbContext;

        public AgentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Agent> AddAgent(Agent agent)
        {
            var result = await _appDbContext.Agents.AddAsync(agent);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Agent?> DeleteAgent(int Id)
        {
            var result = await _appDbContext.Agents.FirstOrDefaultAsync(a => a.Id == Id);
            if (result != null)
            {
                _appDbContext.Agents.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Agent not found");
            }
            return result;
        }

        public async Task<Agent?> GetAgent(int Id)
        {
            var result = await _appDbContext.Agents
                .Include(a => a.Departments)
                .FirstOrDefaultAsync(a => a.Id == Id);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Agent not found");
            }
        }

        public PagedResult<Agent> GetAgents(string? name, int page)
        {
            int pageSize = 5;

            if (name != null)
            {
                return _appDbContext.Agents
                    .Where(a => a.FirstName.Contains(name, StringComparison.CurrentCultureIgnoreCase) ||
                        a.LastName.Contains(name, StringComparison.CurrentCultureIgnoreCase))
                    .OrderBy(a => a.Id)
                    .Include(a => a.Departments)
                    .GetPaged(page, pageSize);
            }
            else
            {
                return _appDbContext.Agents
                    .OrderBy(a => a.Id)
                    .Include(a => a.Departments)
                    .GetPaged(page, pageSize);
            }
        }

        public async Task<Agent?> UpdateAgent(Agent agent)
        {
            var result = await _appDbContext.Agents.Include("Departments").FirstOrDefaultAsync(a => a.Id == agent.Id);
            if (result != null)
            {
                // Update existing Agent
                _appDbContext.Entry(result).CurrentValues.SetValues(agent);

                // Remove deleted Departments
                foreach (var existingDepartment in result.Departments.ToList())
                {
                    if (!agent.Departments.Any(o => o.Id == existingDepartment.Id))
                        _appDbContext.Departments.Remove(existingDepartment);
                }

                // Update and Insert Departments
                foreach (var departmentModel in agent.Departments)
                {
                    var existingDepartment = result.Departments
                        .Where(a => a.Id == departmentModel.Id)
                        .SingleOrDefault();
                    if (existingDepartment != null)
                        _appDbContext.Entry(existingDepartment).CurrentValues.SetValues(departmentModel);
                    else
                    {
                        var newDepartment = new Department
                        {
                            Id = departmentModel.Id,
                            Name = departmentModel.Name,
                            Description = departmentModel.Description,
                            

                        };
                        result.Departments.Add(newDepartment);
                    }
                }
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Agent not found");
            }
            return result;
        }
    }
}
