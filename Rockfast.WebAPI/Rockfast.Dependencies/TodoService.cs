using Microsoft.EntityFrameworkCore;
using Rockfast.ApiDatabase;
using Rockfast.ApiDatabase.DomainModels;
using Rockfast.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockfast.Dependencies
{
    public class TodoService : ITodoService
    {
        private readonly ApiDbContext _database;
        public TodoService(ApiDbContext db)
        {
            this._database = db;
        }

        public async Task<IEnumerable<Todo>> GetAllTodo()
        {
            return await _database.Todos.ToListAsync();
        }

        public async Task<Todo?> GetTodo(int id) 
        {
            return await _database.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
        }

        public async Task CreateTodo(Todo todo)
        {
            todo.DateCreated = DateTime.Now;
            _database.Todos.Add(todo);
            await _database.SaveChangesAsync();
        }

        public async Task UpdateTodo(int id, Todo todo)
        {
            var updatedTodo = await GetTodo(id);
            if (updatedTodo is null)
                return;

            updatedTodo.Name = todo.Name;
            updatedTodo.Complete = todo.Complete;

            await _database.SaveChangesAsync();
        }

        public async Task DeleteTodo(int id) 
        { 
            var todo = await GetTodo(id);
            if(todo is null)
                return;

            _database.Todos.Remove(todo);
            await _database.SaveChangesAsync();
        }
    }
}
