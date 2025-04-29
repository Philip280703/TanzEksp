using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Application.Interfaces
{
    public interface ITripRepository
    {
        Task<List<Trip>> GetAll();
        Task<Trip> GetById(int id);
        Task Add(Trip trip);
        //Task Update(Trip trip);
        //Task Delete(int id);
    }
}
