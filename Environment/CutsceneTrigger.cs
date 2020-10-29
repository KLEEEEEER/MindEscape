using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace DifferentPlanetSession.Environment
{
    public class CutsceneTrigger : MonoBehaviour
    {
        [SerializeField] private PlayableDirector playableDirector;
        private bool isPlayed = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (isPlayed) return;

            playableDirector.Play();
            isPlayed = true;
        }
    }
}