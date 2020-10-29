using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DifferentPlanetSession.Core.Player.Helpers
{
    public class InputListener
    {
        protected PlayerInput _input;
        public InputListener(PlayerInput input)
        {
            _input = input;
        }
        public virtual void AddListener(UnityAction call) {
            
        }
        public virtual void RemoveListener(UnityAction call) { 
            
        }
    }
}