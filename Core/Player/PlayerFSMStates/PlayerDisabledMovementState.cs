using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player.State
{
    public class PlayerDisabledMovementState : PlayerBaseState
    {
        public PlayerDisabledMovementState(PlayerFSM playerFSM) : base(playerFSM)
        {
        }

        public override void LateUpdate()
        {
            fsm.playerCamera.MoveCamera();
        }
    }
}