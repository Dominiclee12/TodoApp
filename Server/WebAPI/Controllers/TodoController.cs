using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Application.Services.Interfaces;
using CoreBusiness.Dtos;
using CoreBusiness.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoServices todoServices;

        public TodoController(ITodoServices todoServices)
        {
            this.todoServices = todoServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = todoServices.GetAll();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(todos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var todo = todoServices.GetById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult Add([FromBody] TodoDto todoDto)
        {
            if (!ModelState.IsValid || todoDto == null)
                return BadRequest(ModelState);

            todoServices.Add(todoDto);

            return Ok("Successfully created.");
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] TodoDto todoDto)
        {
            if (todoServices.GetById(id) == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            todoServices.Update(id, todoDto);

            return Ok("Successfully updated.");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTodo(int id)
        {
            if (todoServices.GetById(id) == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            todoServices.Delete(id);

            return NoContent();
        }
    }
}
