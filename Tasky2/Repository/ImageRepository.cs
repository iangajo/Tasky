using ImageProcessorInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Tasky2.Models;

namespace Tasky2.Repository
{
    public class ImageRepository : IImageRepository
    {
        public List<ImageProcessViewModel> Process()
        {
            var processingImages = new List<ImageProcessViewModel>();
            var processId = 0;
            foreach (var item in Directory.GetFiles(@".\DLLs", "*.dll"))
            {
                var asm = Assembly.LoadFrom(Directory.GetCurrentDirectory() + item);

                foreach (var type in asm.GetTypes())
                {
                    if (!type.GetInterfaces().Contains(typeof(IProcessor))) continue;

                    if (Activator.CreateInstance(type) is IProcessor processor)
                    {
                        processId += 1;
                        var data = processor.Process();
                        processingImages.Add(new ImageProcessViewModel()
                        {
                            ProcessId = processId,
                            ImageTypeProcess = data
                        });
                    }
                }
                
            }

            return processingImages;
        }
    }
}
