using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using log4net;
using log4net.Config;

namespace ConsoleApplicationWithLog4NetAppender
{
    class Program
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
             XmlConfigurator.Configure();
            try
            {
                throw null;
            }
            catch (NullReferenceException e)
            {
                _logger.Error("An error occured", e);
                
            }
        }
    }
}
