using BusinessLogic.Interfaces;
using BusinessLogic.TodoLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Entities;

namespace TodoApi.Controllers
{
    [Route("todo/")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private ITodoData _todoData;

        public TodoController(ITodoData todoData)
        {
            _todoData = todoData;
        }

        //  Get all tasks
        [HttpGet]
        [Route("all")]
        public IActionResult GetTodos()
        {

            try
            {
                return Ok(_todoData.GetTodos());
            }
            catch (Exception e)
            {

                return Problem(detail:e.Message);
            }
        }

        //  Add new Todo
        [HttpPost]
        [Route("")]
        public IActionResult AddTodo(Todo todo)
        {

            try
            {
                _todoData.CreateTodo(todo.Id, todo.Task, todo.Title, todo.Date);
            }
            catch (Exception e)
            {

                return Problem(detail: e.Message);
            }
            return Ok("successful");
        }


        // Update a Todo by Id
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTodo(Guid id, Todo todo)
        {
            try
            {
                // will use object mapper in future
                _todoData.UpdateTodo(id, new BusinessLogic.Entities.Todo
                {
                    Task = todo.Task,
                    Title = todo.Title,
                    Date = todo.Date
                });
            }
            catch (Exception e)
            {

                return Problem(detail: e.Message);
            }
            return Ok("Successful");
        }

        // update datetime of a todo by id
        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateTodoDatetime(Guid id, Todo todo)
        {
            try
            {
                _todoData.UpdateTodoDatetime(id, todo.Date);
            }
            catch (Exception e)
            {

                return Problem(detail: e.Message);
            }
            return Ok("Successfull");
        }

        // Delete a todo by Id
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTodo(Guid id)
        {
            try
            {
                _todoData.DeleteTodo(id);
            }
            catch (Exception e)
            {

                return Problem(detail: e.Message);
            }
            return Ok("Successful");
        }


        // get all todo filtered by datetime and order by title
        [HttpGet("")]
        public IActionResult GetTodoByDatetime(DateTime datetime)
        {
            try
            {
                return Ok(_todoData.GetTodoByDatetime(datetime));
            }
            catch (Exception e)
            {

                return Problem(detail: e.Message);
            }
            
        }

    }
}
