using DifferentPlanetSession.Core.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DifferentPlanetSession.Core.UI
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField] Text healthText;

        PlayerStats playerStats;
        private void Awake()
        {
            playerStats = FindObjectOfType<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.health.OnChange += Health_OnChange;
            }
            else
                Debug.LogError("No PlayerStats object in a scene");


        }

        private void Health_OnChange(float value)
        {
            healthText.text = value.ToString();
        }
    }
}