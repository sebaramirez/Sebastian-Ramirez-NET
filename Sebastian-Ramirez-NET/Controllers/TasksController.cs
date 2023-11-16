using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sebastian_Ramirez_NET.DTOs;
using Sebastian_Ramirez_NET.Infrectuture;
using Sebastian_Ramirez_NET.Models;
using Sebastian_Ramirez_NET.Services;

namespace Sebastian_Ramirez_NET.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("GetAllTasks")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.TaskRepository.GetAll());
        }

        [Route("RegisterTask")]
        [HttpPost]
        public async Task<IActionResult> Register(TaskRegisterDTO taskRegisterDTO) 
        {
            var result = await _unitOfWork.TaskRepository.InsertTask(taskRegisterDTO);
            if (result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Tarea Ingresada Correctamnte");                   
            }
            return ResponseFactory.CreateErrorResponse(400, "Error Al Ingresar Tarea");           
        }

        [Route("UpdateTask")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, TaskRegisterDTO taskRegisterDTO) 
        {
            var result = await _unitOfWork.TaskRepository.UpdataTask(taskRegisterDTO, id);
            if (result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Tarea Actualizada Correctamnte");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error Al Actualizar");
        }

        [Route("DeleteTask")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) 
        {
            var result = await _unitOfWork.TaskRepository.DeleteTask(id);
            if (result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Tarea Eliminada Correctamente");
            }
            return ResponseFactory.CreateErrorResponse(400, "Erroe Al Eliminar");
        }
       
    }
}
