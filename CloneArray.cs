using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoeCode
{
    /// <summary>
    /// Various utility methods to clone or dupe an object into a collection.
    /// </summary>
    public static class CloneArray
    {
        public static T[] Create<T>(T original, int numCopies)
        {
            T[] retval = new T[numCopies];

            for (int i = 0; i < numCopies; i++)
            {
                retval[i] = original;
            }

            return retval;
        }
    }
}