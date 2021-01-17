using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using DataAccessLogic.Interfaces;

namespace BusinessLogic.TodoLogic
{
    public class TodoLogic: ITodoData
    {
        private ITodo _todo;

        public TodoLogic(ITodo todo)
        {
            _todo = todo;
        }
        
        // converting object entity to pass into upper layer
        Todo EntityMapper(DataAccessLogic.Entities.Todo obj)
        {
            return (new Todo
            {
                Id = obj.Id,
                Title = obj.Title,
                Task = obj.Task,
                Date = obj.Date

            });
        }

        // ADD A New USER
        public void CreateTodo(Guid id, string task, string title, DateTime date)
        {
            try
            {
                _todo.AddTodo(id, task, title, date);
             
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteTodo(Guid id)
        {
            try
            {
                _todo.DeleteTodo(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }

        public List<Todo> GetTodoByDatetime(DateTime date)
        {
            List<Todo> todoList = new List<Todo>();
            try
            {
                List<DataAccessLogic.Entities.Todo> tempList = _todo.GetTodoByDatetime(date);
                
                foreach (DataAccessLogic.Entities.Todo obj in tempList)
                {
                    todoList.Add(EntityMapper(obj));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }

            return todoList;
        }

        public List<Todo> GetTodos()
        {          
            List<Todo> todoList = new List<Todo>();
            try
            {
                List<DataAccessLogic.Entities.Todo> tempList = _todo.GetAll();
                foreach (DataAccessLogic.Entities.Todo obj in tempList)
                {
                    todoList.Add(EntityMapper(obj));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
            return todoList;
        }



        public void UpdateTodo(Guid id, Todo todo)
        {
            try
            {
                _todo.UpdateTodo(id, new DataAccessLogic.Entities.Todo
                {
                    Task = todo.Task,
                    Title = todo.Title,
                    Date = todo.Date
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }

        public void UpdateTodoDatetime(Guid id, DateTime date)
        {
            try
            {
                _todo.UpdateTodoDatetime(id, date);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }
    }
}
