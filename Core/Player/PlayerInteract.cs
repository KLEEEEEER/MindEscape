using Cinemachine;
using DifferentPlanetSession.Core.Player.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace DifferentPlanetSession.Core.Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInteract : MonoBehaviour
    {
        [Header("Main attributes")]
        private PlayerInput playerInput;

        public InteractChecker triggerInteractChecker;
        public InteractChecker cameraRayInteractChecker;

        public InputListener useInputListener;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            useInputListener = new UseInputListener(playerInput);
        }
    }
}