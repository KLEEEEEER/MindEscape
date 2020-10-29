using DifferentPlanetSession.Core.Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player
{
    public class PlayerPickupInteractable : MonoBehaviour
    {
        [SerializeField] PlayerInteractFSM playerInteractFSM;
        [SerializeField] string pickupTag;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(pickupTag)) return;


            Interactable item = other.GetComponent<Interactable>();
            if (item == null)
            {
                Debug.Log("No IInventoryItem component");
                return;
            }
            if (!item.IsInteractable(playerInteractFSM.Inventory))
            {
                Debug.Log("!IsInteractable");
                return;
            }

            item.Interact(playerInteractFSM.Inventory);
        }
    }
}