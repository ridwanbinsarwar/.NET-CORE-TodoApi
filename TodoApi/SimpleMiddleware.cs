using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoService
{
    public class SimpleMiddleware
    {
        private readonly RequestDelegate _next;

        public SimpleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async System.Threading.Tasks.Task Invoke(HttpContext context)
        {
            
            string arrivalTime = System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            await _next(context);
            
            string leavingTime = System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");           
            
            string path = "logs.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine("request arrives in: " + arrivalTime + "\n" + "leaves in: " + leavingTime);
                tw.Close();
            }
            else if (File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine("request arrives in: " + arrivalTime + "\n" + "leaves in: " + leavingTime);

                }
            }
           
            
        }
    }
}
