using DifferentPlanetSession.Core.Interactables;
using DifferentPlanetSession.Core.Player.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player.InteractState
{
    public class PlayerInteractTriggerState : PlayerInteractBaseState
    {
        public PlayerInteractTriggerState(PlayerInteractFSM playerInteractFSM) : base(playerInteractFSM)
        {
        }

        public override void OnEnter()
        {
            fsm.playerInteract.useInputListener.AddListener(useButtonPressed);
        }

        public override void FixedUpdate()
        {
            fsm.playerInteract.triggerInteractChecker.Check();
        }

        public override void OnExit()
        {
            fsm.playerInteract.useInputListener.RemoveListener(useButtonPressed);
        }

        private void useButtonPressed()
        {
            Collider collider = fsm.playerInteract.triggerInteractChecker.GetCollider();
            if (collider == null) return;

            Interactable item = collider.GetComponent<Interactable>();
            if (item == null)
            {
                Debug.Log("No IInventoryItem component");
                return;
            }
            if (!item.IsInteractable(fsm.Inventory))
            {
                Debug.Log("!IsInteractable");
                return;
            }
                
            item.Interact(fsm.Inventory);
            //collider.gameObject.transform.position = new Vector3(
            //collider.gameObject.transform.position.x, -10000f, collider.gameObject.transform.position.z);
            //collider.gameObject.SetActive(false);
        }
    }
}