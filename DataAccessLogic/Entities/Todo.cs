using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DataAccessLogic.Entities
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Task { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
