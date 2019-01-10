﻿using mijnZorgRooster.Models.Entities;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
    public interface IUnitOfWork
    {
        IMedewerkerRepository MedewerkerRepository { get; }
        IGenericRepository<Rol> RolRepository { get; }
        Task SaveAsync();
        void Save();
        void Dispose();
    }
}
