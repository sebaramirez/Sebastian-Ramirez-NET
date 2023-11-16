using Sebastian_Ramirez_NET.DTOs;
using Sebastian_Ramirez_NET.Repository;

namespace Sebastian_Ramirez_NET.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ContextDB _contextDB;
        public TaskRepository TaskRepository { get; set; } 
        public UnitOfWorkService(ContextDB contextDB) 
        {
            _contextDB = contextDB;
            TaskRepository = new TaskRepository(contextDB);
        }

        public Task<int> Complete()
        {
            return _contextDB.SaveChangesAsync();
        }
    }
}
