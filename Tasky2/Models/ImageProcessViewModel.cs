using System.ComponentModel.DataAnnotations;

namespace Tasky2.Models
{
    public class ImageProcessViewModel
    {
        [Display(Name = "Process Id")]
        public int ProcessId { get; set; }
        [Display(Name = "Image Type Processed.")]
        public string ImageTypeProcess { get; set; }
    }
}
