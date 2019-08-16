using System;
using System.Linq;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace JoeCode.Extensions
{
    public static class UnityEngineExtensions
    {
        /// <summary>
        /// Extension method that retrieves the first component in a child of
        /// the given type and with the given name.
        /// </summary>
        /// <typeparam name="ComponentType">The type of component to look for.</typeparam>
        /// <param name="name">The name of the GameObject that the component is attached to.</param>
        /// <returns>The first component matching the criteria, or null.</returns>
        public static ComponentType GetComponentInChildrenByName<ComponentType> (this UnityEngine.Component obj, string name) where ComponentType : UnityEngine.Component
        {
            ComponentType[] hits = obj.GetComponentsInChildren<ComponentType>();

            // Stop here if nothing matched at all.
            if (hits.Length > 0) { 
                foreach (ComponentType hit in hits) {
                    if (hit.name == name) return hit;
                }
            }

            return null;
        }

        /// <summary>
        /// Searches through children (and possibly parents) of <paramref name="obj"/>
        /// for any Renderer component, and returns a Bounds object that
        /// encapsulates all the Bounds objects of the Renderers.
        /// </summary>
        /// <param name="searchUpwards">If true, will also search upwards in the object hierarchy, covering the entire object.</param>
        /// <returns></returns>
        /// <remarks>This operation can become <b>very</b> expensive. Use sparingly, and cache the result.</remarks>
        public static Bounds GetCompoundedBounds(this Component obj, bool searchUpwards = false)
        {
            Transform root = obj.transform;

            // If searching upwards, as well, find the root, and use it as a search basis, instead.
            if (searchUpwards)
            {
                while (root.parent != null)
                {
                    root = root.parent;
                }
            }

            IEnumerable<Bounds> bounds = root.GetComponentsInChildren<Renderer>().Select((renderer) => renderer.bounds);

            Bounds megaBound = new Bounds();
            foreach (Bounds b in bounds)
                megaBound.Encapsulate(b);

            return megaBound;
        }

        /// <summary>
        /// Returns true if a <typeparamref name="T"/> component is present.
        /// Simply a shorthand for checking a null return value from
        /// GetComponent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool HasComponent<T>(this Component obj) => obj.GetComponent<T>() != null;

        public static bool HasComponentInChildren<T>(this Component obj) => obj.GetComponentInChildren<T>(true) != null;
    }
}