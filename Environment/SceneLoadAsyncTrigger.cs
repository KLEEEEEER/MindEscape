using DifferentPlanetSession.Core.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DifferentPlanetSession.Environment
{
    public class SceneLoadAsyncTrigger : MonoBehaviour
    {
        [SerializeField] string sceneName;
        private bool isLoaded = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (!isLoaded)
                {
                    SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                    isLoaded = true;
                }
            }
        }
    }
}