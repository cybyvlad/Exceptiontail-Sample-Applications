using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WcfServiceClient.ServiceReference1;

namespace WcfServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BuggyServiceClient client = new BuggyServiceClient())
            {
                client.ThrowsException(1);
            }
        }
    }
}
