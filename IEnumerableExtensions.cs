using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoeCode.Extensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Shuffles the input collection and returns it. Shamelessly torn from
        /// the following StackOverflow exchange:
        /// https://stackoverflow.com/questions/5807128/an-extension-method-on-ienumerable-needed-for-shuffling
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {
            var r = new System.Random();
            return list.
                    Select(x => new { Number = r.Next(), Item = x }).
                    OrderBy(x => x.Number).
                    Select(x => x.Item);
        }
    }
}