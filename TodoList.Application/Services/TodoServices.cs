using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Interfaces;
using TodoList.Application.Services.Interfaces;
using TodoList.CoreBusiness.Dtos;
using TodoList.CoreBusiness.Entities;

namespace TodoList.Application.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly ITodoRepository todoRepository;

        public TodoServices(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public IEnumerable<Todo> GetAll()
        {
            return todoRepository.GetAll();
        }

        public Todo GetById(int id)
        {
            return todoRepository.GetById(id);
        }

        public Todo Add(TodoDto todoDto)
        {
            return todoRepository.Add(todoDto);
        }

        public Todo Update(int id, TodoDto todoDto)
        {
            return todoRepository.Update(id, todoDto);
        }

        public void Delete(int id)
        {
            todoRepository.Delete(id);
        }
    }
}
