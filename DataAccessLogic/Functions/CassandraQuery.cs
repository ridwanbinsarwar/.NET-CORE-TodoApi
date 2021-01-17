using Cassandra;
using DataAccessLogic.DataContext;
using DataAccessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLogic.Functions
{
    class CassandraQuery
    {

        public void Insert(Guid id, string task, string title, DateTime date)
        {
            try
            {
                var _CassandraCon = new CassandraDatabaseConnection();
                var statement = new SimpleStatement("INSERT INTO todo_id (Id, Task, Title, Date) VALUES (?,?,?,?)", id, task, title, date);

                ISession session = _CassandraCon.Connect();
                session.Execute(statement);

                session.Cluster.Shutdown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Cassandra insert error");
            }
            
        }

       

        public void DeleteById(Guid id)
        {
            var _CassandraCon = new CassandraDatabaseConnection();
            ISession session = _CassandraCon.Connect();
            try
            {
                
                var statement = new SimpleStatement("DELETE FROM todo_id WHERE Id = ?", id);

                session.Execute(statement);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Casandra delete by ID error");
            }
            
            session.Cluster.Shutdown();
        }

        public Todo GetTodoById(Guid id)
        {
            var _CassandraCon = new CassandraDatabaseConnection();
            ISession session = _CassandraCon.Connect();
            Todo TempTodo = new Todo();
            try
            {
                var rs = session.Execute(new SimpleStatement("SELECT* FROM todo_id WHERE Id = ?", id));
                

                foreach (var row in rs)
                {
                    TempTodo.Id = row.GetValue<Guid>("id");
                    TempTodo.Task = row.GetValue<string>("task");
                    TempTodo.Title = row.GetValue<string>("title");
                    TempTodo.Date = row.GetValue<DateTime>("date");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("error in Cassandra get Todo By Id");
            }
            
            session.Cluster.Shutdown();
            return TempTodo;
        }

        public List<Todo> GetTodoByDatetime(DateTime date)
        {
            var _CassandraCon = new CassandraDatabaseConnection();

            List<Todo> temp = new List<Todo>();
            try
            {
                var statement = new SimpleStatement("SELECT* FROM todo_id WHERE Date = ?", date);
                ISession session = _CassandraCon.Connect();
                var rs = session.Execute(statement);
                session.Cluster.Shutdown();

                foreach (var row in rs)
                {
                    Todo TempTodo = new Todo();
                    TempTodo.Id = row.GetValue<Guid>("id");
                    TempTodo.Task = row.GetValue<string>("task");
                    TempTodo.Title = row.GetValue<string>("title");
                    TempTodo.Date = row.GetValue<DateTime>("date");

                    temp.Add(TempTodo);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("error in cassandra query");
            }

            return temp;
        }
    }
}
