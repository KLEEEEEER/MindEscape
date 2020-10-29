using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player.State
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerFSM playerFSM) : base(playerFSM)
        {
        }

        public override void OnEnter()
        {
            fsm.playerMovement.jumpInputListener.AddListener(Jump);
        }

        public override void Update()
        {
            if (fsm.playerMovement.GetMovingDirection() != Vector2.zero)
            {
                fsm.SetCurrentState(StateIndex.Running);
            }
        }

        public override void FixedUpdate()
        {
            if (fsm.IsStuckInIdle)
            {
                fsm.playerMovement.Move();
            }
        }

        public override void LateUpdate()
        {
            fsm.playerCamera.MoveCamera();
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