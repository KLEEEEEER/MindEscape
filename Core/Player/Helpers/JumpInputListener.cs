using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DifferentPlanetSession.Core.Player.Helpers
{
    public class JumpInputListener : InputListener
    {
        public JumpInputListener(PlayerInput input) : base(input)
        {
        }

        public override void AddListener(UnityAction call)
        {
            _input.jumpButtonPressed.AddListener(call);
        }

        public override void RemoveListener(UnityAction call)
        {
            _input.jumpButtonPressed.RemoveListener(call);
        }
    }
}