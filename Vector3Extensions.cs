using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoeCode.Extensions
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Returns a <b>new</b> Vector3 where all components have been shifted
        /// with the values of <paramref name="x"/>, <paramref name="y"/>, and
        /// <paramref name="z"/>.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 Shift(this Vector3 v, float x = 0, float y = 0, float z = 0) => new Vector3(v.x + x, v.y + y, v.z + z);

        /// <summary>
        /// Returns a <b>new</b> Vector3 where the x component has been set to
        /// <paramref name="x"/>
        /// </summary>
        /// <param name="v">Vector to modify</param>
        /// <param name="x">New value.</param>
        /// <returns></returns>
        public static Vector3 SetX(this Vector3 v, float x) => new Vector3(x, v.y, v.z);

        /// <summary>
        /// Returns a <b>new</b> Vector3 where the x component has been set to
        /// <paramref name="x"/>
        /// </summary>
        /// <param name="v">Vector to modify</param>
        /// <param name="x">New value.</param>
        /// <returns></returns>
        public static Vector3 SetY(this Vector3 v, float y) => new Vector3(v.x, y, v.z);

        /// <summary>
        /// Returns a <b>new</b> Vector3 where the x component has been set to
        /// <paramref name="x"/>
        /// </summary>
        /// <param name="v">Vector to modify</param>
        /// <param name="x">New value.</param>
        /// <returns></returns>
        public static Vector3 SetZ(this Vector3 v, float z) => new Vector3(v.x, v.y, z);
    }
}