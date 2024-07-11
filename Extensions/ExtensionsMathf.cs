using System;
using UnityEngine;
using Random = System.Random;

namespace Extension.Mathf
{
    public static class ExtensionsMathf
    {
        private static Random sRandom = new Random();

        public static T GetRandom<T>(this T[] array) => array[sRandom.Next(array.Length)]; // GetRandom index from array

        public static Vector2 NormalizedToOne(this Vector2 vector) => vector.magnitude > 1 ? vector.normalized : vector; // Normalizes the vector if the length is greater than one

        
        /// ////////////////////////separate library for enum?
        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(sRandom.Next(v.Length));
        }
        //return (MyEnum) sRandom.Next(Enum.GetNames(typeof(MyEnum)).Length);
        
    }
}