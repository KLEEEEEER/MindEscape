using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player.State
{
    public class PlayerDisabledBothState : PlayerBaseState
    {
        public PlayerDisabledBothState(PlayerFSM playerFSM) : base(playerFSM)
        {
        }
        public override void OnEnter()
        {
            Debug.Log("PlayerDisabledBothState");
            fsm.playerCamera.LockMouse(false);
            fsm.playerMovement.LockMovement(true);
        }

        public override void OnExit()
        {
            fsm.playerCamera.LockMouse(true);
            fsm.playerMovement.LockMovement(false);
        }
    }
}