using System;
using System.Collections.Generic;
using lifeos_api.Models;

namespace lifeos_api.Services
{
    public interface IGoalService
    {
        Task<IEnumerable<Goal>> GetAllAsync();
        Task<Goal?> GetByIdAsync(Guid id);
        Task<Goal> CreateAsync(Goal goal);
        Task<bool> UpdateAsync(Guid id, Goal goal);
        Task<bool> DeleteAsync(Guid id);
    }
}