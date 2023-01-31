using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rockfast.ApiDatabase;
using Rockfast.ApiDatabase.DomainModels;

namespace Rockfast.ServiceInterfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllTodo();
        Task<Todo?> GetTodo(int id);
        Task CreateTodo(Todo todo);
        Task UpdateTodo(int id, Todo todo);
        Task DeleteTodo(int id);
    }
}
