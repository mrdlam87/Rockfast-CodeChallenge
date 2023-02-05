using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rockfast.ApiDatabase;
using Rockfast.ApiDatabase.DomainModels;
using Rockfast.ViewModels;

namespace Rockfast.ServiceInterfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoDTO>> GetAllTodo();
        Task<TodoDTO> GetTodo(int id);
        Task<TodoDTO> CreateTodo(TodoDTO todoDto);
        Task<bool> UpdateTodo(int id, TodoDTO todoDto);
        Task<bool> DeleteTodo(int id);
    }
}
