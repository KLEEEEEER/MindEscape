using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player.State
{
    public class PlayerRunningState : PlayerBaseState
    {
        public PlayerRunningState(PlayerFSM playerFSM) : base(playerFSM)
        {

        }

        public override void OnEnter()
        {
            //Debug.Log("Running State");
            fsm.playerMovement.jumpInputListener.AddListener(Jump);
        }

        public override void Update()
        {
            if (fsm.playerMovement.GetMovingDirection() == Vector2.zero)
            {
                fsm.SetCurrentState(StateIndex.Idle);
            }
        }

        public override void FixedUpdate()
        {
            fsm.playerMovement.Move();
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