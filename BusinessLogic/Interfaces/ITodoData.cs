using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITodoData
    {
        void CreateTodo(Guid id, String task, String title, DateTime date);
        List<Todo> GetTodos();
        void UpdateTodo(Guid id, Todo todo);
        void UpdateTodoDatetime(Guid id, DateTime date);
        void DeleteTodo(Guid id);
        List<Todo> GetTodoByDatetime(DateTime date);
    }
}

