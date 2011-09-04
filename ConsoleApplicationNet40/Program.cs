using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationNet40
{
    class Program
    {
        static void Main(string[] args)
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
