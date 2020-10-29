using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Checkpoints
{
    public class CheckpointChanger : MonoBehaviour
    {
        Checkpoint currentCheckpoint;

        public Checkpoint GetCurrentCheckpoint()
        {
            return currentCheckpoint;
        }

        public void SetCheckpoint(Checkpoint checkpoint)
        {
            currentCheckpoint = checkpoint;
        }
    }
}