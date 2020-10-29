using DifferentPlanetSession.Core.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Cutscenes
{
    public class CutscenePlayer : MonoBehaviour
    {
        PlayerCutsceneController playerCutsceneController;

        public void PlayCutscene(Cutscene cutscene)
        {
            playerCutsceneController.OnBeforeCutsceneShowing();
            cutscene.Play();
        }

        public void StopCurrentCutscene()
        {
            playerCutsceneController.OnCutsceneEnd();
        }
    }
}