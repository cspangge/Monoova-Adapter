using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;

namespace MonoovaAdapter.Utilities
{
    public static class PrintObj
    {
        public static void Print<T>(T obj)
        {
            var serializedText = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(serializedText);
            // foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            // {
            //     var name=descriptor.Name;
            //     var value=descriptor.GetValue(obj);
            //     if (value is IList && value!.GetType().IsGenericType)
            //     {
            //         foreach(PropertyDescriptor subDescriptor in TypeDescriptor.GetProperties(descriptor.GetValue(obj)))
            //         {
            //             var subName=subDescriptor.Name;
            //             var subValue=subDescriptor.GetValue(descriptor.GetValue(obj) ?? "null");
            //             Console.WriteLine("{0}={1}",subName,subValue);
            //         }
            //     }
            //     else
            //     {
            //         try
            //         {
            //             if ((bool) descriptor.GetValue(obj)?.GetType().ToString().Contains("System"))
            //             {
            //                 Console.WriteLine("{0}={1}", name, value);
            //             }
            //             else
            //             {
            //                 Console.WriteLine("----------------------------------------------");
            //                 Print(value);
            //             }
            //         }
            //         catch (Exception exception)
            //         {
            //             Console.WriteLine(exception.StackTrace);
            //         }
            //     }
            // }
        }
    }
}
