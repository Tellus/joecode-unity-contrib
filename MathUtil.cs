using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoeCode
{
    public static class MathUtil
    {
        public class QuadraticFunction
    {
        private float componentA;
        public float ComponentA {
            get => componentA;
            set {
                componentA = value;
                UpdateFunction();
            }
        }

        private float componentB;
        public float ComponentB {
            get => componentB;
            set {
                componentB = value;
                UpdateFunction();
            }
        }
        private float constant;
        public float Constant {
            get => Constant;
            set {
                Constant = value;
                UpdateFunction();
            }
        }

        protected void UpdateFunction()
        {
            Function = (x) => new Vector3(x, this.ComponentA * x * x + this.ComponentB * x + this.Constant);
        }

        protected Func<float, Vector3> Function;

        public QuadraticFunction(float componentA = 1, float componentB = 0, float constant = 0)
        {
            this.ComponentA = componentA;
            this.ComponentB = componentB;
            this.Constant = constant;

            UpdateFunction();
        }

        public Vector3 Call(float x) => this.Function(x);
    }

        /// <summary>
        /// Derives the quadratic function that passes through the three points
        /// given and returns it as a callable.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <remarks>Note that the function returned only works along TWO axes!</remarks>
        public static Func<float, Vector2> DeriveQuadratic(Vector2 pt1, Vector2 pt2, Vector2 pt3)
        {
            // Sort them in x order.
            IList<Vector3> points = new List<Vector3>();
            points.Add(pt1);
            points.Add(pt2);
            points.Add(pt3);

            points = points.OrderBy((p) => p.x).ToList();

            Vector3 p1 = points[0];
            Vector3 p2 = points[1];
            Vector3 p3 = points[2];

            // I've added these variables just to improve readability of the formula.
            float x1 = p1.x, x2 = p2.x, x3 = p3.x, y1 = p1.y, y2 = p2.y, y3 = p3.y;

            // Formula shamelessly ripped from https://www.uvmat.dk/jr/mathpub/TrePktParabel.htm
            return (x) => new Vector2(
                x,
                -(((x - x2) * (x - x3)) / ((x1 - x2) * (x1 - x3))) * y1
                     + (((x - x1) * (x - x3)) / ((x2 - x1) * (x2 - x3))) * y2
                     + (((x - x1) * (x - x2)) / ((x3 - x1) * (x3 - x2))) * y3
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
        public static Func<float, Vector2> DeriveQuadratic(Vector2 pt1, Vector2 pt2, float apexHeight = 0)
        {
            if (apexHeight < 0)
            {
                Debug.LogWarning("DeriveQuadratic: apexHeight is negative! Using absolute value.");
                apexHeight = Mathf.Abs(apexHeight);
            }

            // Ensure point 1 is to the left of point 2.
            if (pt1.x > pt2.x)
            {
                Debug.Log("Point 1 is to the right of Point 2. Swapping.");
                // swap.
                var tmp = pt1;
                pt1 = pt2;
                pt2 = tmp;
            }

            Vector2 pivot;

            if (apexHeight == 0) // If no apex height, use point 2 as pivot and mirror pt1 around it.
            {
                pivot = pt2;
                pt2 = new Vector2(pt2.x + (pt2.x - pt1.x), pt1.y);
            } else // Otherwise, add point midway between pt1 and pt2 that is apexHeight farther up than the higher of the two..
            {
                pivot = new Vector2(pt1.x + Mathf.Abs(pt2.x - pt1.x) / 2, Mathf.Max(pt1.y, pt2.y) + apexHeight);
            }

            return DeriveQuadratic(pt1, pivot, pt2);
        }
    }
}