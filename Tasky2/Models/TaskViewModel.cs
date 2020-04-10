using System.ComponentModel.DataAnnotations;

namespace Tasky2.Models
{
    public class TaskViewModel
    {
        [Display(Name = "Task Name"), MaxLength(50)]
        public string TaskName { get; set; }
        [Display(Name = "Task Description"), MaxLength(150)]
        public string TaskDescription { get; set; }
    }
}
