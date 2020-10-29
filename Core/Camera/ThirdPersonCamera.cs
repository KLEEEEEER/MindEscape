using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Camera
{
    [RequireComponent(typeof(CinemachineFreeLook))]
    public class ThirdPersonCamera : MonoBehaviour
    {
        [SerializeField] public CinemachineFreeLook CM_freeLookCamera { get; private set; }

        private void Awake()
        {
            CM_freeLookCamera = GetComponent<CinemachineFreeLook>();
        }
    }
}