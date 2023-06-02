#region Version scripts = 1.0
#endregion

using System;
using UnityEngine;

namespace Modules.Score
{
    [Serializable]
    public struct Limit
    {
        [SerializeField] private float minValue;
        [SerializeField] private float maxValue;

        public float MinValue => minValue;
        public float MaxValue => maxValue;
        
        public Limit(Limit limit)
        {
            this = limit;
            CheckRightValue();
        }
        
        public Limit(float minValue, float maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            CheckRightValue();
        }

        public float GetLengthLimit()
        {
            return Math.Abs(maxValue - minValue);
        }
        
        private void CheckRightValue()
        {
            if (minValue > maxValue)
            {
                maxValue = minValue;
                ErrorAction();
            }
        }

        private void ErrorAction()
        {
            Debug.LogWarning("Class Limit: try set new object maxValue < minValue.Field MaxValue set as MinValue");
            //throw new ArgumentException();
        }
    }
}


