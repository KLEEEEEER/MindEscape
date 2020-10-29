using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player.State
{
    public class PlayerBaseState
    {
        protected PlayerFSM fsm;

        public PlayerBaseState(PlayerFSM playerFSM)
        {
            fsm = playerFSM;
        }

        public virtual void OnEnter() { }

        public virtual void OnExit() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }
        public virtual void LateUpdate() { }
    }
}