using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Application.Interfaces
{
	public interface ITripEventRepository
	{
		Task<List<TripEvent>> GetAll();
		Task<TripEvent> GetById(int id);
		Task Add (TripEvent tripEvent);
		Task Update (TripEvent tripEvent);
		Task Delete (int id);
	}
}
