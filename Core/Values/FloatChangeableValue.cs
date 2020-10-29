using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Values
{
    public class FloatChangeableValue
    {
        private float _value;
        public event Action<float> OnChange;

        public FloatChangeableValue(float startValue = 0f)
        {
            _value = startValue;
        }

        public float GetValue() => _value;
        public void SetValue(float value) 
        {
            _value = value;
            if (OnChange != null)
                OnChange.Invoke(_value);
        }
    }
}