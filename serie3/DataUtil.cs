using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace serie3
{
    public class DataUtil
    {
        /// <summary>
        /// Utilitary function to iterate over any enumberable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        public static void Each<T>(IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items) action(item);
        }
    }
}