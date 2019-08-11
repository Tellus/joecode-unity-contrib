using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoeCode
{
    public static class UnityHelpers
    {
        /// <summary>
        /// Creates a Texture2D with the given dimensions and a flat color.
        /// </summary>
        /// <param name="width">Width, in pixels, of the texture.</param>
        /// <param name="height">Height, in pixels, of the texture.</param>
        /// <param name="color">Color for the texture.</param>
        /// <returns>The new texture is returned once drawn.</returns>
        public static Texture2D CreateColoredTexture2D(int width, int height, Color color)
        {
            Texture2D tex = new Texture2D(width, height);

            tex.SetPixels(CloneArray.Create(color, width * height));
            tex.Apply();

            return tex;
        }
    }
}