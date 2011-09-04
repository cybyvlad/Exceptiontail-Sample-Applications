using System;
using System.Collections.Generic;

namespace BuggyApp.Wp
{
    public static class Thrower
    {
        private static List<Type> _knownExceptions;
        private static readonly Random _rand = new Random();

        public static void Throw()
        {
            T1();
        }

        private static void T1()
        {
            WayBiggerFunctionName1();
        }

        private static void WayBiggerFunctionName1()
        {
            WayBiggerFunctionName2();
        }

        private static void WayBiggerFunctionName2()
        {
            WayBiggerFunctionName3(0);
        }

        private static void WayBiggerFunctionName3(int count)
        {
            if (count < 10)
            {
                WayBiggerFunctionName3(++count);
            }

            throw FindExceptionToThrow();
        }

        private static Exception FindExceptionToThrow()
        {
            if (_knownExceptions == null)
            {
                _knownExceptions = new List<Type>
                                       {
                                           typeof (AccessViolationException),
                                           typeof (AppDomainUnloadedException),
                                           typeof (ArgumentException),
                                           typeof (ArgumentNullException),
                                           typeof (ArgumentOutOfRangeException),
                                           typeof (ArithmeticException),
                                           typeof (ArrayTypeMismatchException),
                                           typeof (BadImageFormatException),
                                           typeof (CannotUnloadAppDomainException),
                                           typeof (DataMisalignedException),
                                           typeof (DivideByZeroException),
                                           typeof (DllNotFoundException),
                                           typeof (FormatException),
                                           typeof (FieldAccessException)
                                       };
            }
            var random = _rand.Next(_knownExceptions.Count);
            var findExceptionToThrow = (Exception) Activator.CreateInstance(_knownExceptions[random]);
            findExceptionToThrow.Data["This is some extra data"] = "data";
            return findExceptionToThrow;
        }
    }
}