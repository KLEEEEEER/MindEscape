using DifferentPlanetSession.Core.Player.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player.InventorySystem
{
    [CreateAssetMenu(fileName = "_InventoryItemSO", menuName = "Inventory/New inventory item SO")]
    public class InventoryItemSO : ScriptableObject
    {
        [Header("Main Attributes")]
        public Sprite icon;
        public string itemName = string.Empty;
    }
}