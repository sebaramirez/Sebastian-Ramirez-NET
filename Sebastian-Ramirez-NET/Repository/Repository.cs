using Microsoft.EntityFrameworkCore;
using Sebastian_Ramirez_NET.DTOs;
using Sebastian_Ramirez_NET.Repository.Interfaces;

namespace Sebastian_Ramirez_NET.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ContextDB _contextDB;
        public Repository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }
        
        public async Task<List<T>> GetAll() 
        {
            try
            {
                var entity = await _contextDB.Set<T>().ToListAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> Insert(T entity) 
        {
            try
            {
                _contextDB.Set<T>().Add(entity);
                await _contextDB.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> Update(T entity) 
        {
            try
            {
                _contextDB.Set<T>().Update(entity);
                await _contextDB.SaveChangesAsync(); 
                return true;
            }
            catch (Exception ex)
            {                
                return false;
            }           
        }
       
    }
}
