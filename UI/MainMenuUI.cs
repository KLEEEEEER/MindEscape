using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace DifferentPlanetSession.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private PlayableDirector playableDirector;
        [SerializeField] private PlayableAsset cutsceneAsset;

        public void OnStartPressed()
        {
            Debug.Log("OnStartPressed");
            //playableDirector.playableAsset = cutsceneAsset;
            playableDirector.Play();
            gameObject.SetActive(false);
        }

        public void OnExitPressed()
        {
            Application.Quit();
        }
    }
}