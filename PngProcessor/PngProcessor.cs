using System;
using ImageProcessorInterface;

namespace PngProcessor
{
    public class PngProcessor : IProcessor
    {
        public string Process()
        {
            return "Png Processed.";
        }
    }
}
