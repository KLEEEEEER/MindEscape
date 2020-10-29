using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DifferentPlanetSession.Core.Player.Helpers
{
    public class TriggerInteractChecker : InteractChecker
    {
        [SerializeField] private float interactRadius = 1f;
        [SerializeField] private LayerMask interactableMask;

        Collider[] triggerResults = new Collider[20];

        public override void Check()
        {
            triggerResults[0] = null;
            Physics.OverlapSphereNonAlloc(transform.position, interactRadius, triggerResults, interactableMask);
        }

        public override Collider GetCollider()
        {
            Collider returnCollider = triggerResults[0];
            //triggerResults[0] = null;

            return returnCollider;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawWireSphere(transform.position, interactRadius);
        }
    }
}