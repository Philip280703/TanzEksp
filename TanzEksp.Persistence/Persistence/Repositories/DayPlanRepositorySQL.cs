using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Application.Interfaces;
using TanzEksp.Domain.Entities;
using TanzEksp.Infrastructure.Persistence.EFContext;

namespace TanzEksp.Infrastructure.Persistence.Repositories
{
    public class DayPlanRepositorySQL : IDayPlanRepository
    {
        private AppDbContext _db;
        private IUnitOfWork _unitOfWork;

        public DayPlanRepositorySQL(AppDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DayPlan>> GetAll()
        {
            var result = await _db.DayPlanEF.ToListAsync();
            return result;
        }

        public async Task<DayPlan> GetById(int id)
        {
            var result = await _db.DayPlanEF.SingleOrDefaultAsync(d => d.Id == id);
            return result;
        }

        public async Task Add(DayPlan dayPlan)
        {
            await _db.DayPlanEF.AddAsync(dayPlan);
            await _db.SaveChangesAsync();
        }

        public async Task Update(DayPlan dayPlan)
        {
            var existingdayplan = await GetById(dayPlan.Id); // Vent på asynkrone metode
            _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);
            try
            {
                if (existingdayplan != null)
                {
                    existingdayplan.Meals = dayPlan.Meals;
                    existingdayplan.Description = dayPlan.Description;
                    existingdayplan.Title = dayPlan.Title;
                    existingdayplan.Accommodation = dayPlan.Accommodation;
                    existingdayplan.RowVersion = dayPlan.RowVersion; // Opdater RowVersion for at undgå concurrency problemer
                }
                _unitOfWork.Commit();
                await _db.SaveChangesAsync(); // Brug asynkrone version
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception("Error updating customer", ex);
            }
        }

        public async Task Delete(int id)
        {
            var dayplan = await GetById(id);
            if (dayplan != null)
            {
                _db.DayPlanEF.Remove(dayplan);
                await _db.SaveChangesAsync();
            }
        }
    }
}

