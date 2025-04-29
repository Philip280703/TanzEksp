using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Application.Interfaces;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Application.UseCases
{
    public class TripUseCase
    {
        private readonly ITripRepository _tripRepository;
        public TripUseCase(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<List<Trip>> GetAll()
        {
            return await _tripRepository.GetAll();
        }

        public async Task<Trip> GetById(int id)
        {
            return await _tripRepository.GetById(id);
        }

        public async Task Add(Trip trip)
        {
            await _tripRepository.Add(trip);
        }

        //public async Task Update(Trip trip)
        //{
        //    await _tripRepository.Update(trip);
        //}

        //public async Task Delete(int id)
        //{
        //    await _tripRepository.Delete(id);
        //}
    }
}
