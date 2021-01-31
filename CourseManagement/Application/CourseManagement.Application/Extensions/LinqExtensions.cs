using System;
using System.Collections.Generic;

namespace CourseManagement.Application.Extensions
{
    public static class LinqExtensions
    {
        public static void ForEachWithIndex<T>(this List<T> list, Action<T, int> handler)
        {
            int index = 0;
            foreach (T item in list)
                handler(item, index++);
        }
    }
}
