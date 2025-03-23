using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.CoreBusiness.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Task name cannot be longer than 30 characters.")]
        public string? TaskName { get; set; } = "";
        public bool IsCompleted { get; set; } = false;
    }
}
