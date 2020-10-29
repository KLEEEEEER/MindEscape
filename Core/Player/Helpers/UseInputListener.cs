using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DifferentPlanetSession.Core.Player.Helpers
{
    public class UseInputListener : InputListener
    {
        public UseInputListener(PlayerInput input) : base(input)
        {
        }

        public override void AddListener(UnityAction call)
        {
            _input.useButtonPressed.AddListener(call);
        }

        public override void RemoveListener(UnityAction call)
        {
            _input.useButtonPressed.RemoveListener(call);
        }
    }
}