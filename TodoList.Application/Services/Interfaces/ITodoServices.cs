using TodoList.CoreBusiness.Dtos;
using TodoList.CoreBusiness.Entities;

namespace TodoList.Application.Services.Interfaces
{
    public interface ITodoServices
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);
        Todo Add(TodoDto todoDto);
        Todo Update(int id, TodoDto todoDto);
        void Delete(int id);
    }
}