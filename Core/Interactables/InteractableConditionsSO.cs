using DifferentPlanetSession.Core.Player.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Interactables
{
    [CreateAssetMenu(fileName = "_InteractableCondition", menuName = "Interactable/New interactable condition")]
    public class InteractableConditionsSO : ScriptableObject
    {
        public InventoryItemSO[] itemsToInteract;
    }
}