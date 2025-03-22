using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.CoreBusiness.Dtos
{
    public class TodoDto
    {
        [Required]
        public string TaskName { get; set; } = "";
        public bool IsCompleted { get; set; } = false;
    }
}
