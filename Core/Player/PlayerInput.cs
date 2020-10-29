using DifferentPlanetSession.Core.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace DifferentPlanetSession.Core.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] PauseMenuUI pauseMenuUI;

        public UnityEvent jumpButtonPressed = new UnityEvent();
        public UnityEvent useButtonPressed = new UnityEvent();

        public float Vertical { get; private set; }
        public float Horizontal { get; private set; }
        public bool IsMovingLocked { get; private set; }
        public bool IsVerticalMovementLocked { get; private set; }

        private void Awake()
        {
            IsMovingLocked = false;
            IsVerticalMovementLocked = false;
        }

        public void OnMove(InputValue value)
        {
            if (IsMovingLocked)
            {
                Horizontal = 0f;
                Vertical = 0f;
                return;
            }

            Vector2 movingDirection = value.Get<Vector2>().normalized;

            Horizontal = movingDirection.x;
            Vertical = (!IsVerticalMovementLocked) ? movingDirection.y : 0f;
        }

        public void LockMovement(bool enabled)
        {
            IsMovingLocked = enabled;
        }

        public void LockVerticalMovement(bool enabled)
        {
            IsVerticalMovementLocked = enabled;
        }

        public void OnJump(InputValue value)
        {
            jumpButtonPressed.Invoke();
        }

        public void OnUse(InputValue value)
        {
            useButtonPressed.Invoke();
        }

        public void OnPause(InputValue value) 
        {
            if (IsMovingLocked) return;

            if (pauseMenuUI.gameObject.activeSelf)
            {
                pauseMenuUI.gameObject.SetActive(false);
            }
            else
            {
                pauseMenuUI.gameObject.SetActive(true);
            }
        }
    }
}