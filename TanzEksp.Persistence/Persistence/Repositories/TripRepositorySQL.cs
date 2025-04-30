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
    public class TripRepositorySQL : ITripRepository
    {
        private AppDbContext _db;
        private IUnitOfWork _unitOfWork;

        public TripRepositorySQL(AppDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Trip>> GetAll()
        {
            var result = await _db.TripEF.ToListAsync();
            return result;
        }

        public async Task<Trip> GetById(int id)
        {
            var result = await _db.TripEF.SingleOrDefaultAsync(t => t.Id == id);
            return result;
        }

        public async Task Add(Trip trip)
        {
            await _db.TripEF.AddAsync(trip);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var trip = await GetById(id);
            if (trip != null)
            {
                _db.TripEF.Remove(trip);
                await _db.SaveChangesAsync();
            }
        }
    }
}
