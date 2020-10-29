using DifferentPlanetSession.Core.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Environment
{
    public class CameraChangeTrigger : MonoBehaviour
    {
        [SerializeField] PlayerCamera playerCamera;
        [SerializeField] PlayerMovement playerMovement;
        [SerializeField] PlayerInput playerInput;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerCamera.SetMainCamera(playerCamera.CM_2DCamera);
                playerMovement.SetJumpForce(500f);
                playerInput.LockVerticalMovement(true);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerCamera.SetMainCamera(playerCamera.CM_freeLookCamera);
                playerMovement.SetJumpForce(300f);
                playerInput.LockVerticalMovement(false);
            }
        }
    }
}