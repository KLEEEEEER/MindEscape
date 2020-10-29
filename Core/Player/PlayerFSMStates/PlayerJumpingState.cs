using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player.State
{
    public class PlayerJumpingState : PlayerBaseState
    {
        public PlayerJumpingState(PlayerFSM playerFSM) : base(playerFSM)
        {
        }

        float currentTime = 0f;

        public override void OnEnter()
        {
            currentTime = 0f;
            Debug.Log("Jumping State");
            fsm.playerMovement.Jump();
        }

        public override void Update()
        {
            currentTime += Time.deltaTime;
        }

        public override void FixedUpdate()
        {
            if (fsm.CanAirControl)
            {
                fsm.playerMovement.Move();
            }

            if (currentTime < fsm.playerMovement.waitTimeAfterJump) return;

            if (fsm.playerMovement.IsGrounded)
            {
                fsm.SetCurrentState(StateIndex.Idle);
            }
        }

        public override void LateUpdate()
        {
            fsm.playerCamera.MoveCamera();
        }
    }
}