﻿using System;

namespace SampleConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ExceptionTail.ET.Initialize("d2e9f3f7-475c-4efb-a163-93d3d81a5cf9");
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