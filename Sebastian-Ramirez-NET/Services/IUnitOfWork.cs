using Sebastian_Ramirez_NET.Repository;

namespace Sebastian_Ramirez_NET.Services
{
    public interface IUnitOfWork
    {
        public TaskRepository TaskRepository { get; set; }
        public Task<int> Complete();
    }
}
