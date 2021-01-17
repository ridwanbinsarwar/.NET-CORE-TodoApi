using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
