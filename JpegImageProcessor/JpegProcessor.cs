using System;
using ImageProcessorInterface;

namespace JpegImageProcessor
{
    public class JpegProcessor : IProcessor
    {
        public string Process()
        {
            return "Jpeg Processed.";
        }
    }
}
