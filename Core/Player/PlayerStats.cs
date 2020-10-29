using DifferentPlanetSession.Core.Values;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private float startHealth;
        public FloatChangeableValue health = new FloatChangeableValue();

        private void Start()
        {
            InitializeValues();
        }

        private void InitializeValues()
        {
            health.SetValue(startHealth);
        }
    }
}