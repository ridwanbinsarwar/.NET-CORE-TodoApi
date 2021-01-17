using DataAccessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLogic.Interfaces
{
    public interface ITodo
    {
        void AddTodo(Guid id, string task, string title, DateTime date);
        List<Todo> GetAll();
        void UpdateTodo(Guid id, Todo todo);
        void UpdateTodoDatetime(Guid id, DateTime date);
        void DeleteTodo(Guid id);
        List<Todo> GetTodoByDatetime(DateTime date);
    }
}
