using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player
{
    public class PlayerCutsceneController : MonoBehaviour
    {
        public PlayerMovement playerMovement;
        public PlayerCamera playerCamera;
        public PlayerStateChanger playerStateChanger;

        public void OnBeforeCutsceneShowing()
        {
            playerStateChanger.SetMovementState(StateIndex.DisabledBoth);
        }

        public void Move()
        {

        }

        public void OnCutsceneEnd()
        {
            playerStateChanger.SetMovementState(StateIndex.Idle);
        }
    }
}