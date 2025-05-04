using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TanzEksp.Application.Interfaces;
using TanzEksp.Domain.Entities;
using TanzEksp.Infrastructure.Persistence.EFContext;

namespace TanzEksp.Infrastructure.Persistence.Repositories
{
    public class BookingRepositorySQL : IBookingRepository
    {
        private AppDbContext _db;
        private IUnitOfWork _unitOfWork;

        public BookingRepositorySQL(AppDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }


        public async Task<Booking> GetBookingById(Guid id)
        {
            var result = await _db.BookingEF.SingleOrDefaultAsync(b => b.Id == id);

            return result;
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            var result = await _db.BookingEF.Include(b=>b.Trip).ToListAsync();
            return result;
        }

        public async Task AddBooking(Booking booking)
        {
            await _db.BookingEF.AddAsync(booking);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateBooking(Booking booking)
        {
            var existingBooking = await GetBookingById(booking.Id);
            _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);
            try
            {
                if (existingBooking != null)
                {
                    existingBooking.AdultCount = booking.AdultCount;
                    existingBooking.ChildCount = booking.ChildCount;
                    existingBooking.Airport = booking.Airport;
                    existingBooking.DepartureDate = booking.DepartureDate;
                    existingBooking.TripLength = booking.TripLength;
                }
                     
                //if (booking.Customer != null)
                //{
                //    existingBooking.Customer.FirstName = booking.Customer.FirstName;
                //    existingBooking.Customer.LastName = booking.Customer.LastName;
                //    existingBooking.Customer.PhoneNumber = booking.Customer.PhoneNumber;
                //    existingBooking.Customer.Email = booking.Customer.Email;
                //}

                //if (booking.Trip != null)  
                //{
                //    var existingTrip = await _db.TripEF.FindAsync(booking.Trip.Id);
                //    if (existingTrip != null)
                //    {
                //        existingTrip.TripType = booking.Trip.TripType;
                //        existingTrip.StartDate = booking.Trip.StartDate;
                //        // vi skal måske tilføje slutdato, pris, description, navn, Start lokation osv.
                //    }
                //    else
                //    {
                //        existingBooking.TripId = booking.TripId;
                //    }
                //}

                _unitOfWork.Commit();
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception("Error updating booking", ex);
            }
        }

        public async Task DeleteBooking(Guid id)
        {
            var existingBooking = await GetBookingById(id);
            if (existingBooking != null)
            {
                _db.BookingEF.Remove(existingBooking);
                await _db.SaveChangesAsync();
            }
        }
    }
}
