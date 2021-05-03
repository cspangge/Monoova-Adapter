using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MonoovaAdapter.Utilities
{
    public static class PrintObj
    {
        public static void Print<T>(T obj)
        {
            foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                var name=descriptor.Name;
                var value=descriptor.GetValue(obj);
                if (value is IList && value!.GetType().IsGenericType && !name.Equals("durationMs") && !name.Equals("status") && !name.Equals("statusDescription"))
                {
                    foreach(PropertyDescriptor subDescriptor in TypeDescriptor.GetProperties(descriptor.GetValue(obj)))
                    {
                        var subName=subDescriptor.Name;
                        var subValue=subDescriptor.GetValue(descriptor.GetValue(obj) ?? "null");
                        Console.WriteLine("{0}={1}",subName,subValue);
                    }
                }
                else
                {
                    Console.WriteLine("{0}={1}",name,value);
                }
            }
        }
    }
}
