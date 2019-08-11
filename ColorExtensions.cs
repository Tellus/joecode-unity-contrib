using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoeCode.Extensions
{
    /// <summary>
    /// Extension methods to UnityEngine.Color.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Returns a version of this color where all color channels (r,g,b)
        /// have been modified by the amount specified by <paramref name="shiftBy"/>.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="shiftBy"></param>
        /// <returns></returns>
        public static Color ShiftBrightness(this Color color, float shiftBy)
        {
            return new Color(color.r + shiftBy, color.g + shiftBy, color.b + shiftBy);
        }

        
    }
}