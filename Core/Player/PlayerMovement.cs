using Cinemachine;
using DifferentPlanetSession.Core.Player.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace DifferentPlanetSession.Core.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Main attributes")]
        [SerializeField] private float speed = 10f;
        [SerializeField] private float speedLimit = 10f;
        [SerializeField] private float jumpForce = 100f;
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private PlayerInput playerInput;
        //[SerializeField] private CinemachineFreeLook cm_freeLookCamera;
        [SerializeField] private PlayerCamera playerCamera;
        [SerializeField] private Animator amimator;

        [Header("Rotations")]
        [SerializeField] private float rotationTime = 1f;
        private Vector3 previousMove = Vector3.zero;
        private float startTime = 0f;

        [Header("Grounded check")]
        [SerializeField] private float checkGroundedDistance = 0.5f;
        [SerializeField] public float waitTimeAfterJump = 1f;
        [SerializeField] private LayerMask groundMask;

        // Listeners
        public InputListener jumpInputListener;


        private Vector3 playerVelocity;
        private Vector3 move;
        private Vector3 rotationVelocity = Vector3.zero;

        private bool isGrounded = false;
        public bool IsGrounded => isGrounded;

        private void Awake()
        {
            jumpInputListener = new JumpInputListener(playerInput);
        }

        public void Jump()
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Force);
        }

        public void Move()
        {
            amimator.SetFloat("Speed", Mathf.Clamp(Mathf.Abs(playerInput.Vertical) + Mathf.Abs(playerInput.Horizontal), 0f, 1f) * speed);
            move = Vector3.forward * playerInput.Vertical + Vector3.right * playerInput.Horizontal;
            move *= speed;
            Quaternion cameraRotation = Quaternion.Euler(0f, playerCamera.GetMainCamera().m_XAxis.Value, 0f);
            move = cameraRotation * move;
            rigidbody.AddForce(move, ForceMode.Force);

            float fallSpeed = rigidbody.velocity.y;
            Vector3 newVelocity = Vector3.ClampMagnitude(rigidbody.velocity, speedLimit);
            newVelocity.y = fallSpeed;
            rigidbody.velocity = newVelocity;
        }

        public void LockMovement(bool enabled)
        {
            playerInput.LockMovement(enabled);
        }

        public Vector2 GetMovingDirection()
        {
            return new Vector2(playerInput.Vertical, playerInput.Horizontal);
        }

        private void FixedUpdate()
        {
            isGrounded = CheckGrounded();
            amimator.SetBool("IsNotGrounded", !isGrounded);

            if (isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
        }

        private void Update()
        {
            rigidbody.angularVelocity = Vector3.zero;

            transform.forward = Vector3.SmoothDamp(transform.forward, move, ref rotationVelocity, rotationTime);
        }

        private bool CheckGrounded()
        {
            return Physics.Raycast(transform.position, -transform.up, checkGroundedDistance, groundMask);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, -transform.up * checkGroundedDistance);
        }

        public void SetJumpForce(float force)
        {
            jumpForce = force;
        }
    }
}