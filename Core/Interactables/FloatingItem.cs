using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Interactables
{
    public class FloatingItem : MonoBehaviour
    {
        [SerializeField] float rotationSpeed = 1f;

        private void Update()
        {
            transform.Rotate(0f, Time.deltaTime * rotationSpeed, 0f, Space.Self);
        }
    }
}