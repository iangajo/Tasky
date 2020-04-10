using System.Collections.Generic;
using Tasky2.Models;

namespace Tasky2.Repository
{
    public interface IImageRepository
    {
        List<ImageProcessViewModel> Process();
    }
}
