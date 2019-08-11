using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JoeCode.Extensions
{
    /// <summary>
    /// Extension methods for TextMeshPro.
    /// </summary>
    public static class TextMeshProExtensions
    {
        /// <summary>
        /// Attempts to set a single unicode character based on its hex value.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fromText"></param>
        public static void SetUnicodeCharacter(this TextMeshPro obj, string fromText)
        {
            int unicode = int.Parse(fromText, System.Globalization.NumberStyles.HexNumber);

            obj.SetUnicodeCharacter(unicode);
        }

        /// <summary>
        /// Attempts to set a single unicode character based on its hex value.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fromText"></param>
        public static void SetUnicodeCharacter(this TextMeshPro obj, int unicode)
        {
            obj.SetText(char.ConvertFromUtf32(unicode));
        }

        /// <summary>
        /// Attempts to set a single unicode character based on its hex value.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fromText"></param>
        public static void SetUnicodeCharacter(this TextMeshProUGUI obj, string fromText)
        {
            int unicode = int.Parse(fromText, System.Globalization.NumberStyles.HexNumber);

            obj.SetUnicodeCharacter(unicode);
        }

        /// <summary>
        /// Attempts to set a single unicode character based on its hex value.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fromText"></param>
        public static void SetUnicodeCharacter(this TextMeshProUGUI obj, int unicode)
        {
            obj.SetText(char.ConvertFromUtf32(unicode));
        }
    }
}