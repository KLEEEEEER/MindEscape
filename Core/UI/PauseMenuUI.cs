using DifferentPlanetSession.Core.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DifferentPlanetSession.Core.UI
{
    public class PauseMenuUI : MonoBehaviour
    {
        [SerializeField] Slider mouseSensVertical;
        [SerializeField] Slider mouseSensHorizontal;

        private void OnEnable()
        {
            mouseSensVertical.value = MainSettings.mouseSensitivityVertical;
            mouseSensHorizontal.value = MainSettings.mouseSensitivityHorizontal;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;
            mouseSensHorizontal.onValueChanged.AddListener(MainSettings.SetHorizontalSensitivity);
            mouseSensVertical.onValueChanged.AddListener(MainSettings.SetVerticalSensitivity);
        }

        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
            mouseSensHorizontal.onValueChanged.RemoveListener(MainSettings.SetHorizontalSensitivity);
            mouseSensVertical.onValueChanged.RemoveListener(MainSettings.SetVerticalSensitivity);
        }

        public void OnExitButtonPressed()
        {
            Application.Quit();
        }
    }
}