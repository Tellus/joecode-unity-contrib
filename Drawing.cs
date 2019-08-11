using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JoeCode.Extensions;

namespace JoeCode
{
    /// <summary>
    /// Various methods that use the Debug.DrawLine method.
    /// </summary>
    public static class Drawing
    {
        /// <summary>
        /// Draws an X centered around the given position.
        /// </summary>
        /// <param name="position">Center of the X.</param>
        /// <param name="color">Color of the lines.</param>
        /// <param name="size">Size of each of the lines.</param>
        public static void DrawCross(Vector3 position, Color color, float size = 1.0f)
        {
            Vector3 p = position; // Shorthand.

            Debug.DrawLine(p.Shift(x: -size / 2, y: -size / 2), p.Shift(x: size / 2, y: size / 2), color);
            Debug.DrawLine(p.Shift(x: -size / 2, y: size / 2), p.Shift(x: size / 2, y: -
               size / 2), color);
        }
    }
}