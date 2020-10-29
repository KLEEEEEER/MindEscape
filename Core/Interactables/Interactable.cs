using DifferentPlanetSession.Core.Player.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Interactables
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] protected InteractableConditionsSO interactableConditions;
        public virtual bool IsInteractable(Inventory inventory)
        {
            return CheckConditionsInInventory(inventory);
        }
        public virtual void Interact(Inventory inventory)
        {
            RemoveConditionsFromInventory(inventory);
        }

        protected void RemoveConditionsFromInventory(Inventory inventory)
        {
            foreach (var item in interactableConditions.itemsToInteract)
            {
                inventory.RemoveItem(item);
            }
        }

        protected bool CheckConditionsInInventory(Inventory inventory)
        {
            foreach (var item in interactableConditions.itemsToInteract)
            {
                InventoryItem foundItem = inventory.HasItem(item);
                if (foundItem == null) return false;
            }
            return true;
        }
    }
}