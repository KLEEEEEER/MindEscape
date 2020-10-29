using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DifferentPlanetSession.Core.Player.Helpers
{
    public class CameraRayInteractChecker : InteractChecker
    {
        [SerializeField] private float distance = 2f;

        RaycastHit cameraRayResult;

        public override void Check()
        {
            Physics.Raycast(transform.position, transform.forward, out cameraRayResult, distance);
        }

        public override Collider GetCollider()
        {
            return cameraRayResult.collider;
        }
    }
}