using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.CoreBusiness.Dtos;
using TodoList.CoreBusiness.Entities;

namespace TodoList.Application.Interfaces
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);
        Todo Add(TodoDto todoDto);
        Todo Update(int id, TodoDto todoDto);
        void Delete(int id);
    }
}
