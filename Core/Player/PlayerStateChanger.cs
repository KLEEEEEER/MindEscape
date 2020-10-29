using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

namespace DifferentPlanetSession.Core.Player
{
    [RequireComponent(typeof(PlayerFSM))]
    public class PlayerStateChanger : MonoBehaviour
    {
        [SerializeField] private PlayableDirector startCutsceneDirector;
        private PlayerFSM playerFsm;

        private void Awake()
        {
            playerFsm = GetComponent<PlayerFSM>();
        }

        private void Start()
        {
            //SetMovementState(StateIndex.DisabledBoth);
            startCutsceneDirector.stopped += StartCutsceneDirector_stopped;
        }

        private void StartCutsceneDirector_stopped(PlayableDirector obj)
        {
            SetMovementState(StateIndex.Idle);
        }

        public void SetMovementState(StateIndex state)
        {
            playerFsm.SetCurrentState(state);
        }

        /*public void OnDisableCamera(InputValue value)
        {
            playerFsm.SetCurrentState(StateIndex.DisabledCamera);
        }
        public void OnDisablePlayer(InputValue value)
        {
            playerFsm.playerCamera.SetMainCamera(playerFsm.playerCamera.CM_2DCamera);
        }
        public void OnDisableMovement(InputValue value)
        {
            playerFsm.SetCurrentState(StateIndex.DisabledMovement);
        }*/
    }
}