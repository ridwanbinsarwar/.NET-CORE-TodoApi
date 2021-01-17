using DataAccessLogic.DataContext;
using DataAccessLogic.Entities;
using DataAccessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cassandra.Mapping;
using Cassandra;
using System.Linq;

namespace DataAccessLogic.Functions
{
    public class TodoFunctions: ITodo
    {

        SqlQuery sqlQuery = new SqlQuery();
        CassandraQuery cassandraQuery = new CassandraQuery();

        // ADD A new Todo
        public void AddTodo(Guid id, string task, string title, DateTime date)
        {
            try
            {
                sqlQuery.Insert(id, task, title, date);

                cassandraQuery.Insert(id, task, title, date);
            }
            catch { throw; }
        }

        // Delete a Todo
        public void DeleteTodo(Guid id)
        {
            try
            {
                sqlQuery.DeleteById(id);
                cassandraQuery.DeleteById(id);
            }
            catch { throw; }
        }

        // GET ALL Todo

        public List<Todo>  GetAll()
        {
            List<Todo>allTodos;
            try
            {
                allTodos = sqlQuery.GetAll();
            }
            catch { throw; }
            return allTodos;
        }
        // get all todo filtered by datetime and order by title
        public List<Todo> GetTodoByDatetime(DateTime date)
        {
            List<Todo> tempTodo;
            try
            {
                tempTodo = cassandraQuery.GetTodoByDatetime(date);
            }
            catch { throw; }
            return tempTodo;
        }

        
        public void UpdateTodo(Guid id, Todo todo)
        {
            try
            {
                sqlQuery.Update(id, todo);

                // can't update cluster key 
                // so delete the todo and insert updated todo
                
                cassandraQuery.DeleteById(id);
                cassandraQuery.Insert(id, todo.Task, todo.Title, todo.Date);
            }
            catch { throw; }
        }

        public void UpdateTodoDatetime(Guid id, DateTime date)
        {

            try
            {
                sqlQuery.UpdateDatetime(id, date);

                 // can't update cluster key
                // so delete the todo and insert updated todo
                Todo TempTodo = cassandraQuery.GetTodoById(id);
                cassandraQuery.DeleteById(id);
                cassandraQuery.Insert(id, TempTodo.Task, TempTodo.Title, date);
            }
            catch { throw; } 
        }
    }
}
