using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoeCode
{
    public delegate Vector2 GraphFunction2DCallable(float x);

    public static class MathUtil
    {
        /// <summary>
        /// Derives the quadratic function that passes through the three points
        /// given and returns it as a callable.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <remarks>Note that the function returned only works along TWO axes!</remarks>
        public static GraphFunction2DCallable DeriveQuadratic(Vector2 pt1, Vector2 pt2, Vector2 pt3)
        {
            if (pt1.x == pt2.x || pt1.x == pt3.x || pt2.x == pt3.x)
                throw new ArgumentException("Two points CANNOT share the same x position.");

            // I've added these variables just to improve readability of the formula.
            float x1 = pt1.x, x2 = pt2.x, x3 = pt3.x, y1 = pt1.y, y2 = pt2.y, y3 = pt3.y;

            // Formula shamelessly ripped from https://www.uvmat.dk/jr/mathpub/TrePktParabel.htm
            float div1 = (x1 - x2) * (x1 - x3);
            float div2 = (x2 - x1) * (x2 - x3);
            float div3 = (x3 - x1) * (x3 - x2);

            if (div1 == 0 || div2 == 0 || div3 == 0)
                throw new DivideByZeroException("One of the divisors would become 0. Are all the points present on the intended curve?");

            return (x) => new Vector2(
                x,
                (((x - x2) * (x - x3)) / div1) * y1
                 + (((x - x1) * (x - x3)) / div2) * y2
                 + (((x - x1) * (x - x2)) / div3) * y3
            );
        }

        /// <summary>
        /// Derives the quadratic function that passes through the three points,
        /// where the center point is halfway between <paramref name="pt1"/> and
        /// <paramref name="pt2"/> and lies at a height <paramref name="apexHeight"/>
        /// <b>above</b> the higher of the two points.
        /// </summary>
        /// <param name="p1">Left-most point.</param>
        /// <param name="p2">Right-most point.</param>
        /// <param name="apexHeight"></param>
        /// <remarks>Note that the function returned only works along TWO axes!</remarks>
        public static GraphFunction2DCallable DeriveQuadratic(Vector2 pt1, Vector2 pt2, float apexHeight = 0)
        {
            float pivotHeight;

            if (apexHeight > 0) pivotHeight = Mathf.Max(pt1.y, pt2.y) + Mathf.Abs(apexHeight);
            else if (apexHeight < 0) pivotHeight = Mathf.Min(pt1.y, pt2.y) - Mathf.Abs(apexHeight);
            else throw new ArgumentOutOfRangeException("apexHeight cannot be 0!");

            Vector2 leftMost = pt1.x < pt2.x ? pt1 : pt2;

            Vector2 pivot = new Vector2(leftMost.x + Mathf.Abs(pt1.x - pt2.x) / 2, apexHeight);

            return DeriveQuadratic(pt1, pivot, pt2);
        }

        /// <summary>
        /// Returns the vector that is farthest to the left along the x axis.
        /// It's just a shorthand for the ternary operator but makes code
        /// easier to read.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 LeftMost(Vector3 a, Vector3 b) => a.x < b.x ? a : b;

        /// <summary>
        /// Returns the vector that is farthest to the left along the x axis.
        /// It's just a shorthand for the ternary operator but makes code
        /// easier to read.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector2 LeftMost(Vector2 a, Vector2 b) => a.x < b.x ? a : b;

        /// <summary>
        /// Returns the vector that is farthest to the left along the x axis.
        /// It's just a shorthand for the ternary operator but makes code
        /// easier to read.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector3 RightMost(Vector3 a, Vector3 b) => a.x > b.x ? a : b;

        /// <summary>
        /// Returns the vector that is farthest to the left along the x axis.
        /// It's just a shorthand for the ternary operator but makes code
        /// easier to read.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector2 RightMost(Vector2 a, Vector2 b) => a.x > b.x ? a : b;
    }

    public abstract class GraphFunction2D
    {
        public Vector2 Get(float x) => function(x);

        public GraphFunction2DCallable function {
            get; private set;
        }

        protected GraphFunction2D(GraphFunction2DCallable fn)
        {
            function = fn;
        }

        public void DrawDebugLines(Vector3 startPoint, Vector3 endPoint, Color color, int stepCount = 10) => DrawDebugLines(startPoint.x, endPoint.x, color, stepCount);

        public void DrawDebugLines(float from, float to, Color color, int stepCount = 10)
        {
            float leftMost = from < to ? from : to;

            float stepSize = Mathf.Abs(from - to) / stepCount;

            for (int i = 0; i < stepCount; i++)
            {
                Debug.DrawLine(Get(leftMost + stepSize * i), Get(leftMost + stepSize * (i + 1)), color);
            }
        }

        public void DrawDebugLines(Vector3 startPoint, Vector3 endPoint) => DrawDebugLines(startPoint, endPoint, Color.red);
    }

    public class QuadraticFunction : GraphFunction2D
    {
        public readonly List<Vector2> sourcePoints = new List<Vector2>();

        public QuadraticFunction(Vector2 pt1, Vector2 pt2, Vector2 pt3) : base(MathUtil.DeriveQuadratic(pt1, pt2, pt3)) {
            sourcePoints.Add(pt1);
            sourcePoints.Add(pt2);
            sourcePoints.Add(pt3);
        }

        public QuadraticFunction(Vector2 pt1, Vector2 pt2, float apexHeight) : base(MathUtil.DeriveQuadratic(pt1, pt2, apexHeight)) {
            sourcePoints.Add(pt1);
            sourcePoints.Add(pt2);
        }
    }
}