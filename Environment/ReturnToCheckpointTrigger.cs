using DifferentPlanetSession.Checkpoints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DifferentPlanetSession.Environment
{
    public class ReturnToCheckpointTrigger : MonoBehaviour
    {
        [SerializeField] private CheckpointChanger checkpointChanger;
        [SerializeField] private Image fader;

        private void Start()
        {
            Color fixedColor = fader.color;
            fixedColor.a = 1;
            fader.color = fixedColor;
            fader.CrossFadeAlpha(0f, 0f, true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            Checkpoint checkpoint = checkpointChanger.GetCurrentCheckpoint();

            StartCoroutine(returningCoroutine(checkpoint, other));
        }

        IEnumerator returningCoroutine(Checkpoint checkpoint, Collider other)
        {
            fader.CrossFadeAlpha(1f, 1f, false);
            yield return new WaitForSeconds(1f);
            other.gameObject.transform.position = checkpoint.checkpointPosition.position;
            other.gameObject.transform.rotation = checkpoint.checkpointPosition.rotation;
            fader.CrossFadeAlpha(0f, 1f, false);
        }
    }
}