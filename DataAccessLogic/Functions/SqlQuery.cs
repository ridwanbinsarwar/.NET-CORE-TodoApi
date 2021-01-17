using DataAccessLogic.DataContext;
using DataAccessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLogic.Functions
{
    class SqlQuery
    {
        public void Insert(Guid id, string task, string title, DateTime date)
        {
            Todo NewTodo = new Todo
            {
                Id = id,
                Task = task,
                Title = title,
                Date = date
            };
            using (var context = new SqlDatabaseContext(SqlDatabaseContext.ops.dbOptions))
            {
                try
                {
                    context.todos.Add(NewTodo);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw new Exception("SQL insert error");
                }
            }
        }

        public void DeleteById(Guid id)
        {
            Todo DelTodo;
            try
            {
                using (var context = new SqlDatabaseContext(SqlDatabaseContext.ops.dbOptions))
                {
                    DelTodo = context.todos.Find(id);
                }

                using (var context = new SqlDatabaseContext(SqlDatabaseContext.ops.dbOptions))
                {
                    if (DelTodo != null)
                    {
                        context.todos.Remove(DelTodo);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("SQL Delete error");
            }
        }

        public List<Todo> GetAll()
        {
            List<Todo> allTodos;
            var context = new SqlDatabaseContext(SqlDatabaseContext.ops.dbOptions);
            try
            {
                allTodos = context.todos.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("SQL getAll error");
            }
            return allTodos;
        }

        public void Update(Guid id, Todo todo)
        {
            Todo UplTodo;
            try
            {
                using (var context = new SqlDatabaseContext(SqlDatabaseContext.ops.dbOptions))
                {
                    UplTodo = context.todos.Find(id);
                }


                using (var context = new SqlDatabaseContext(SqlDatabaseContext.ops.dbOptions))
                {
                    if (UplTodo != null)
                    {
                        todo.Id = id;
                        context.todos.Update(todo);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("SQL Update error");
            }
        }

        public void UpdateDatetime(Guid id, DateTime date)
        {
            try
            {
                using (var context = new SqlDatabaseContext(SqlDatabaseContext.ops.dbOptions))
                {
                    Todo tempTodo = new Todo { Id = id };
                    tempTodo.Date = date;
                    context.Entry(tempTodo).Property("Date").IsModified = true;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("SQL UpdateDatetime error");
            }
        }
    }
}
