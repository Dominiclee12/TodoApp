using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TodoList.Application.Services.Interfaces;
using TodoList.CoreBusiness.Entities;
using TodoList.WebAPI.Controllers;

namespace TodoList.UnitTest
{
    public class TodoControllerTests
    {
        private readonly Mock<ITodoServices> mockServices;
        private readonly TodoController controller;
        public TodoControllerTests()
        {
            this.mockServices = new Mock<ITodoServices>();
            this.controller = new TodoController(this.mockServices.Object);
        }

        [Fact]
        public void GetAll_ReturnsOkResult_WithListOfTodos()
        {
            // Arrange
            var mockTodos = new List<Todo>
            {
                new Todo {Id = 1, TaskName = "Morning workout (30 minutes)", IsCompleted = false},
                new Todo {Id = 2, TaskName = "Prepare breakfast", IsCompleted = false}
            };
            this.mockServices.Setup(s => s.GetAll()).Returns(mockTodos);

            // Act
            var result = this.controller.GetAll() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.IsType<List<Todo>>(result.Value);
            Assert.Equal(2, ((List<Todo>)result.Value).Count);
        }

        [Fact]
        public void GetById_ReturnsTodo_WhenTodoIsExists()
        {
            // Arrange
            var mockTodo = new Todo { Id = 1, TaskName = "Morning workout (30 minutes)", IsCompleted = false };
            this.mockServices.Setup(s => s.GetById(1)).Returns(mockTodo);

            // Act
            var result = this.controller.GetById(1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.IsType<Todo>(result.Value);
        }

        [Fact]
        public void GetById_ReturnsNotFound_WhenTodoNotExists()
        {
            // Arrange
            this.mockServices.Setup(s => s.GetById(1)).Returns((Todo)null);

            // Act
            var result = this.controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
