using CoreBusiness.Dtos;
using CoreBusiness.Entities;

namespace Application.Services.Interfaces
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