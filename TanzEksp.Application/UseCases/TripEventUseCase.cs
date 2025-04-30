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
	public class TripEventUseCase
	{
		private readonly ITripEventRepository _tripEventRepository;

		public TripEventUseCase(ITripEventRepository tripEventRepository)
		{
			_tripEventRepository = tripEventRepository;
		}

		public async Task<List<TripEvent>> GetAll()
		{
			return await _tripEventRepository.GetAll();
		}

		public async Task<TripEvent> GetByid(int id)
		{
			return await _tripEventRepository.GetById(id);
		}

		public async Task Add(TripEvent tripEvent)
		{
			await _tripEventRepository.Add(tripEvent);
		}

		public async Task Update(TripEvent tripEvent)
		{
			await _tripEventRepository.Update(tripEvent);
		}

		public async Task Delete(int id)
		{
			await _tripEventRepository.Delete(id);
		}
	}
}
