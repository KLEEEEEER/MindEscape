using DifferentPlanetSession.Core.Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player.InventorySystem
{
    public class InventoryItem : Interactable
    {
        public string itemName = string.Empty;
        public InventoryItemSO inventoryItemToUse;
        public virtual void Use() { }

        public override void Interact(Inventory inventory = null)
        {
            inventory.AddItem(this);
            inventory.DebugItems();
            gameObject.SetActive(false);
        }

        public override bool IsInteractable(Inventory inventory)
        {
            return (interactableConditions != null && interactableConditions.itemsToInteract.Length > 0) ? CheckConditionsInInventory(inventory) : true;
        }
    }
}