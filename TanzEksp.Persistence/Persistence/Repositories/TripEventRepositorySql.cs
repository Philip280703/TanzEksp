using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Application.Interfaces;
using TanzEksp.Domain.Entities;
using TanzEksp.Infrastructure.Persistence.EFContext;

namespace TanzEksp.Infrastructure.Persistence.Repositories
{
	public class TripEventRepositorySql : ITripEventRepository
	{

		private AppDbContext _db;
		private IUnitOfWork _unitOfWork;

		public TripEventRepositorySql(AppDbContext db, IUnitOfWork unitOfWork)
		{
			_db = db;
			_unitOfWork = unitOfWork;
		}
		public async Task Add(TripEvent tripEvent)
		{
			await _db.AddAsync(tripEvent);
			await _db.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var tripEvent = await GetById(id);
			if (tripEvent != null)
			{
				_db.TripEventEF.Remove(tripEvent);
				await _db.SaveChangesAsync();
			}
		}

		public async Task<List<TripEvent>> GetAll()
		{
			var result  = await _db.TripEventEF.Include(te => te.DayPlans).ToListAsync();
			return result;
		}

		public async Task<TripEvent> GetById(int id)
		{
			var result = await _db.TripEventEF.FirstOrDefaultAsync(te => te.Id == id);
			return result;
		}

		public async Task Update(TripEvent tripEvent)
		{
			var existingTripEvent = await GetById(tripEvent.Id);
			_unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);
			try
			{
				if (existingTripEvent != null)
				{
					existingTripEvent.Priority = tripEvent.Priority;
                    existingTripEvent.Title = tripEvent.Title;
					existingTripEvent.Description = tripEvent.Description;
					existingTripEvent.Days = tripEvent.Days;
					existingTripEvent.Price = tripEvent.Price;
					existingTripEvent.RowVersion = tripEvent.RowVersion; // Opdater RowVersion for at undgå concurrency problemer
                }
				await _db.SaveChangesAsync();
				_unitOfWork.Commit();
			}
			catch (Exception ex)
			{
				_unitOfWork.Rollback();
				throw new Exception("Error updating tripevent", ex);
			}


		}


	}
}
