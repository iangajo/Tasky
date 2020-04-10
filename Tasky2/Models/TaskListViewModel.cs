using System.ComponentModel.DataAnnotations;

namespace Tasky2.Models
{
    public class TaskListViewModel
    {
        [Display(Name = "Task Id")]
        public int TaskId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }
        [Display(Name = "Task Description")]
        public string TaskDescription { get; set; }
        [Display(Name = "Mark as done")]
        public bool IsCompleted { get; set; }
    }
}
