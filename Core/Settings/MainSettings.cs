using UnityEngine;

namespace DifferentPlanetSession.Core.Settings
{
    public class MainSettings : MonoBehaviour
    {
        public static float mouseSensitivityVertical = 0.03f;
        public static float mouseSensitivityHorizontal = 3f;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            mouseSensitivityVertical = PlayerPrefs.GetFloat("VerticalSensitivity", 0.03f);
            mouseSensitivityHorizontal = PlayerPrefs.GetFloat("HorizontalSensitivity", 3f);
        }

        public static void SetVerticalSensitivity(float value)
        {
            PlayerPrefs.SetFloat("VerticalSensitivity", value);
            mouseSensitivityVertical = value;
        }

        public static void SetHorizontalSensitivity(float value)
        {
            PlayerPrefs.SetFloat("HorizontalSensitivity", value);
            mouseSensitivityHorizontal = value;
        }
    }
}