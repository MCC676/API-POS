﻿using POS.Infraestructure.FileStorage;

namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Declaración o matrícula de nuestras interfaces a nivel de repositorio
        ICategoryRepository Category { get; }
        IUserRepository User { get; }

        IAzureStorage Storage { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
