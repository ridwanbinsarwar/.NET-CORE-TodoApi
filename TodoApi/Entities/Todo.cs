using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}



