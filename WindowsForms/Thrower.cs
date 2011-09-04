using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.ServiceModel;
using System.Threading;
using System.Web;
using System.Windows.Forms;

using Microsoft.CSharp;

namespace BuggyApp
{
    public static class Thrower
    {
        public static void Throw()
        {
            T1();
        }

        private static void T1()
        {
            WayBigger_Function_Name1();
        }

        private static void WayBigger_Function_Name1()
        {
            WayBigger_Function_Name2();
        }

        private static void WayBigger_Function_Name2()
        {
            WayBigger_Function_Name3(0);
        }

        private static void WayBigger_Function_Name3(int count)
        {
            if (count <10)
            {
                WayBigger_Function_Name3(++count);
            }
            
            throw FindExceptionToThrow();
        }

        private static List<Type> KnownExceptions;
        private static Random rand = new Random();
        private static Exception FindExceptionToThrow()
        {
            if (KnownExceptions == null)
            {
                var q = GetQ(typeof(object));
                KnownExceptions = q.ToList();
                q = GetQ(typeof(Form));
                KnownExceptions.AddRange(q.ToList());
                q = GetQ(typeof(HttpApplication));
                KnownExceptions.AddRange(q.ToList());
                q = GetQ(typeof(IQueryable));
                KnownExceptions.AddRange(q.ToList());
                q = GetQ(typeof(CSharpCodeProvider));
                KnownExceptions.AddRange(q.ToList());
                q = GetQ(typeof(IChannel));
                KnownExceptions.AddRange(q.ToList());
                q = GetQ(typeof(ServiceHost));
                KnownExceptions.AddRange(q.ToList());
            }
            var random = rand.Next(KnownExceptions.Count);
            var findExceptionToThrow = Activator.CreateInstance(KnownExceptions[random]) as Exception;
            findExceptionToThrow.Data["This is some extra data"] = "data";
            return findExceptionToThrow;
        }

        private static IEnumerable<Type> GetQ(Type type)
        {
            IEnumerable<Type> q;
            q = from t in Assembly.GetAssembly(type).GetTypes()
                where t.IsClass && t.FullName.EndsWith("Exception") && t.GetConstructor(Type.EmptyTypes) != null
                select t;
            return q;
        }
    }
}