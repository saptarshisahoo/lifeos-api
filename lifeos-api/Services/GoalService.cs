using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lifeos_api.Data;
using lifeos_api.Models;

namespace lifeos_api.Services
{
    public class GoalService : IGoalService
    {
        private readonly AppDbContext _db;

        public GoalService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Goal>> GetAllAsync()
        {
            return await _db.Goals.AsNoTracking().ToListAsync();
        }

        public async Task<Goal?> GetByIdAsync(Guid id)
        {
            return await _db.Goals.FindAsync(id);
        }

        public async Task<Goal> CreateAsync(Goal goal)
        {
            goal.Id = Guid.NewGuid();
            goal.CreatedAt = DateTime.UtcNow;
            _db.Goals.Add(goal);
            await _db.SaveChangesAsync();
            return goal;
        }

        public async Task<bool> UpdateAsync(Guid id, Goal goal)
        {
            var existing = await _db.Goals.FindAsync(id);
            if (existing == null) return false;

            existing.Title = goal.Title;
            existing.Description = goal.Description;
            existing.DueDate = goal.DueDate;
            existing.IsCompleted = goal.IsCompleted;

            _db.Goals.Update(existing);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _db.Goals.FindAsync(id);
            if (existing == null) return false;

            _db.Goals.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}