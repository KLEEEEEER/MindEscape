using Cinemachine;
using DifferentPlanetSession.Core.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace DifferentPlanetSession.UI
{
    public class EndMenuUI : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera cinemachineCamera;
        [SerializeField] PlayerStateChanger playerStateChanger;
        private void OnEnable()
        {
            cinemachineCamera.gameObject.SetActive(true);
            playerStateChanger.SetMovementState(StateIndex.DisabledBoth);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void OnSoundcloudPressed()
        {
            Application.OpenURL("https://soundcloud.com/maxnitals");
        }

        public void OnItchioPressed()
        {
            Application.OpenURL("https://maxnitals.itch.io/");
        }

        public void OnExitPressed()
        {
            Application.Quit();
        }
    }
}