using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player.State
{
    public class PlayerDisabledCameraState : PlayerBaseState
    {
        public PlayerDisabledCameraState(PlayerFSM playerFSM) : base(playerFSM)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("Disabled camera State");
            fsm.playerMovement.jumpInputListener.AddListener(Jump);
        }

        public override void FixedUpdate()
        {
            fsm.playerMovement.Move();
        }

        public override void OnExit()
        {
            fsm.playerMovement.jumpInputListener.RemoveListener(Jump);
        }

        private void Jump()
        {
            if (fsm.playerMovement.IsGrounded)
            {
                fsm.SetCurrentState(StateIndex.Jumping);
            }
        }
    }
}