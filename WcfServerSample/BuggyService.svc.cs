using System;
using System.Threading;

namespace WcfServerSample
{
    [ErrorHandlerServiceBehaviour]
    public class BuggyService : IBuggyService
    {
        #region IBuggyService Members
        public string ThrowsException(int value)
        {
            throw null;
        }

        public string DoesNotRespond(int value)
        {
            Thread.Sleep(TimeSpan.FromDays(2));
            return string.Empty;
        }
        #endregion
    }
}