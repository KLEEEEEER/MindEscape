using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DifferentPlanetSession.Core.Player.Helpers
{
    public class InteractChecker : MonoBehaviour
    {
        public virtual void Check() { }
        public virtual Collider GetCollider() { return null; }
    }
}