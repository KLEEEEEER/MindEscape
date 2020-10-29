using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player.InteractState
{
    public class PlayerInteractBaseState
    {
        protected PlayerInteractFSM fsm;

        public PlayerInteractBaseState(PlayerInteractFSM playerInteractFSM)
        {
            fsm = playerInteractFSM;
        }

        public virtual void OnEnter() { }

        public virtual void OnExit() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }
        public virtual void LateUpdate() { }
    }
}