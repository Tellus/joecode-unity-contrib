using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoeCode.Extensions
{
    public static class UriExtensions
    {
        public static IEnumerable<string> LocalPathParts(this Uri uri) => uri.LocalPath.Trim('/').Split('/');
        public static IEnumerable<string> AbsolutePathParts(this Uri uri) => uri.AbsolutePath.Trim('/').Split('/');
    }
}