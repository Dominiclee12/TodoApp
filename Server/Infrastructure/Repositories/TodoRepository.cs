using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using CoreBusiness.Dtos;
using CoreBusiness.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext context;

        //private List<Todo> todos;
        public TodoRepository(AppDbContext context)
        {
            this.context = context;
            //this.todos = new List<Todo>()
            //{
            //    new Todo { Id = 1, TaskName = "Morning workout", IsCompleted = false },
            //    new Todo { Id = 2, TaskName = "Prepare breafast", IsCompleted = false },
            //    new Todo { Id = 3, TaskName = "Complete assignment", IsCompleted = false },
            //    new Todo { Id = 4, TaskName = "Evening meditation", IsCompleted = false }
            //};
        }

        public IEnumerable<Todo> GetAll()
        {
            return context.Todos.ToList();
        }

        public Todo GetById(int id)
        {
            var todo = context.Todos.FirstOrDefault(x => x.Id == id);

            return todo;
        }

        public Todo Add(TodoDto todoDto)
        {
            var newTodo = new Todo();

            newTodo.TaskName = todoDto.TaskName;
            newTodo.IsCompleted = todoDto.IsCompleted;

            context.Add(newTodo);
            context.SaveChanges();

            return newTodo;
        }

        public Todo Update(int id, TodoDto todoDto)
        {
            var updateTodo = context.Todos.First(x => x.Id == id);

            updateTodo.TaskName = todoDto.TaskName;
            updateTodo.IsCompleted = todoDto.IsCompleted;

            context.SaveChanges();

            return updateTodo;
        }

        public void Delete(int id)
        {
            var deleteTodo = context.Todos.First(x => x.Id == id);

            context.Remove(deleteTodo);
            context.SaveChanges();
        }
    }
}
