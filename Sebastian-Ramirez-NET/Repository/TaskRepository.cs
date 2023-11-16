using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Sebastian_Ramirez_NET.DTOs;
using Sebastian_Ramirez_NET.Entites;
using Sebastian_Ramirez_NET.Models;
using System.Security.Cryptography.X509Certificates;

namespace Sebastian_Ramirez_NET.Repository
{
    public class TaskRepository : Repository<TaskEntites>
    {
        public TaskRepository(ContextDB contextDB) : base(contextDB) 
        {
        }

        public async Task<List<TaskEntites>> GetAllTasks() 
        {
            try
            {
                return await _contextDB.Tasks.Where(x => x.IsCompleted == false).ToListAsync();

            }
            catch (Exception ex)
            {

                throw null;
            }
            
        }

        public async Task<TaskEntites?> GetTaskId(int id) 
        {
            try
            {
                return await _contextDB.Tasks.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> InsertTask(TaskRegisterDTO taskRegisterDTO) 
        {
            try
            {
                var tasks = new TaskEntites();
                tasks = taskRegisterDTO;
                return await base.Insert(tasks);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> UpdataTask(TaskRegisterDTO taskRegisterDTO, int id) 
        {
            try
            {
                var tasks = new TaskEntites();
                tasks = taskRegisterDTO;
                tasks.Id = id;
                tasks.IsCompleted = taskRegisterDTO.IsCompleted;

                return await base.Update(tasks);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> DeleteTask(int id) 
        {
            try
            {
                var task = await GetTaskId(id);
                task.IsCompleted = true;

                return await base.Update(task);
            }
            catch (Exception ex)
            {

                return false;
            }
        } 


       
    }
}
