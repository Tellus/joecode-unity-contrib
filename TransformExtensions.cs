using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoeCode.Extensions
{
    /// <summary>
    /// Extension methods for UnityEngine.Transform.
    /// </summary>
    public static class TransformExtensions
    {
        public static void ShiftPosition(this Transform transform, float x = 0, float y = 0, float z = 0)
        {
            Vector3 pos = transform.position;
            pos.x += x;
            pos.y += y;
            pos.z += z;

            transform.position = pos;
        }

        public static void ShiftLocalPosition(this Transform transform, float x = 0, float y = 0, float z = 0)
        {
            Vector3 pos = transform.localPosition;
            pos.x += x;
            pos.y += y;
            pos.z += z;

            transform.localPosition = pos;
        }
    }
}