using System;
using System.Reflection;

using log4net;
using log4net.Config;

namespace ConsoleApplicationWithLog4NetAppender
{
    internal class Program
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static void Main(string[] args)
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