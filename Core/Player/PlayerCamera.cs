using Cinemachine;
using DifferentPlanetSession.Core.Camera;
using DifferentPlanetSession.Core.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DifferentPlanetSession.Core.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        public bool IsLockedCamera { get; private set; }

        public Vector2 LookDirection { get; private set; }

        [SerializeField] private ThirdPersonCamera thirdPersonCamera;
        [SerializeField] private float horizontalSensitivity = 10f;
        [SerializeField] private float verticalSensitivity = 0.1f;
        [SerializeField] public CinemachineFreeLook CM_freeLookCamera;
        [SerializeField] public CinemachineFreeLook CM_2DCamera;
        private CinemachineFreeLook mainCamera;

        private void Start()
        {
            mainCamera = CM_freeLookCamera;

            //LockMouse(true);
        }

        public void OnLook(InputValue value)
        {
            if (IsLockedCamera)
            {
                LookDirection = Vector2.zero;
                return;
            }

            Vector2 lookingDirection = value.Get<Vector2>();
            lookingDirection.y *= -1;
            LookDirection = lookingDirection;
        }

        /*private void LateUpdate()
        {
            MoveThirdPersonCamera(LookDirection);
        }*/

        public void MoveThirdPersonCamera(Vector2 direction)
        {
            //thirdPersonCamera.CM_freeLookCamera.m_XAxis.Value += direction.x * horizontalSensitivity * Time.deltaTime;
            //thirdPersonCamera.CM_freeLookCamera.m_YAxis.Value += direction.y * verticalSensitivity * Time.deltaTime;
            thirdPersonCamera.CM_freeLookCamera.m_XAxis.Value += direction.x * MainSettings.mouseSensitivityHorizontal * Time.deltaTime;
            thirdPersonCamera.CM_freeLookCamera.m_YAxis.Value += direction.y * MainSettings.mouseSensitivityVertical * Time.deltaTime;
        }

        public void MoveCamera()
        {
            if (mainCamera == CM_freeLookCamera)
            {
                //CM_freeLookCamera.m_XAxis.Value += LookDirection.x * horizontalSensitivity * Time.deltaTime;
                //CM_freeLookCamera.m_YAxis.Value += LookDirection.y * verticalSensitivity * Time.deltaTime;
                CM_freeLookCamera.m_XAxis.Value += LookDirection.x * MainSettings.mouseSensitivityHorizontal * Time.deltaTime;
                CM_freeLookCamera.m_YAxis.Value += LookDirection.y * MainSettings.mouseSensitivityVertical * Time.deltaTime;
            }
            else
            {

            }
        }

        public void LockMouse(bool locking)
        {
            if (locking)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void SetMainCamera(CinemachineFreeLook camera)
        {
            mainCamera.m_Priority = 9;
            camera.m_Priority = 10;
            mainCamera = camera;
        }

        public CinemachineFreeLook GetMainCamera()
        {
            return mainCamera;
        }
    }
}