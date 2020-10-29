using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Checkpoints
{
    public class Checkpoint : MonoBehaviour
    {
        public Transform checkpointPosition;
        private CheckpointChanger checkpointChanger;

        private void Awake()
        {
            checkpointChanger = FindObjectOfType<CheckpointChanger>();
            if (checkpointChanger == null) Debug.LogError("There is no CheckpointChanger object");
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;

            checkpointChanger.SetCheckpoint(this);
        }
    }
}