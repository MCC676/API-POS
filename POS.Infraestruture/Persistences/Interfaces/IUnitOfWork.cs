namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Declaración o matrícula de nuestras interfaces a nivel de repositorio
        ICategoryRepository Category { get; }
        IUserRepository User { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
