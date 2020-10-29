using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Environment
{
    [RequireComponent(typeof(Rigidbody))]
    public class StayOnPlatformTrigger : MonoBehaviour
    {
        Rigidbody rb;
        Rigidbody playerRb;
        [SerializeField] MovingPlatform movingPlatform;
        [SerializeField] float directionSpeedMultiplier = 50f;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (playerRb == null)
                    playerRb = collision.gameObject.GetComponent<Rigidbody>();

                if (playerRb == null)
                    return;

                playerRb.AddForce(movingPlatform.GetDirectionAndSpeed() * directionSpeedMultiplier, ForceMode.VelocityChange);

                Debug.Log("Added velocity");
            }
        }
    }
}