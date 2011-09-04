using System;

namespace SampleConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ExceptionTail.ET.Initialize("YOUR_API_KEY");
            try
            {
                throw null;
            }
            catch (NullReferenceException e)
            {
                ExceptionTail.ET.Publish(e);
                
            }
        }
    }
}