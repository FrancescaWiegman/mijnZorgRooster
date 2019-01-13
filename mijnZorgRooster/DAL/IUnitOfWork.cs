﻿using mijnZorgRooster.Models.Entities;
using System.Threading.Tasks;

namespace mijnZorgRooster.DAL
{
    public interface IUnitOfWork
    {
        IMedewerkerRepository MedewerkerRepository { get; }
		IGenericRepository<DienstProfiel> DienstProfielRepository { get; }
		IGenericRepository<Dienst> DienstRepository { get; }
		IGenericRepository<Rooster> RoosterRepository { get; }
        IGenericRepository<Rol> RolRepository { get; }
        IGenericRepository<Certificaat> CertificaatRepository { get; }
        Task SaveAsync();
        void Save();
        void Dispose();
    }
}
