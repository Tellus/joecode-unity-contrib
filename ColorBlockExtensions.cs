using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JoeCode.Extensions
{
    public static class ColorBlockExtensions
    {
        /// <summary>
        /// Colors an entire color block (for buttons, for example) using
        /// a base color with slight shifts for the alternate modes.
        /// </summary>
        /// <param name="block">The block to color</param>
        /// <param name="normal">The base (normal) color.</param>
        public static ColorBlock SetAllFromColor(this ColorBlock block, Color normal)
        {
            // Normal.
            block.normalColor = normal;
            // Lighten.
            block.highlightedColor = normal.ShiftBrightness(0.5f);
            // Darken 1.
            block.selectedColor = normal.ShiftBrightness(-0.3f);
            // Darken 2.
            block.pressedColor = normal.ShiftBrightness(-0.7f);

            return block;
        }
    }
}