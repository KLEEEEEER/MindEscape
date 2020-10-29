using DifferentPlanetSession.Core.Interactables;
using DifferentPlanetSession.Core.Player.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DifferentPlanetSession.Interactables
{
    public class Door : Interactable
    {
        //Vector3 rotateToOpen = new Vector3(0f, -90f, 0f);
        [SerializeField] float openingSpeed = 2f;
        [SerializeField] Transform doorWrapper;
        Quaternion rotateToOpen = Quaternion.Euler(0f, 60f, 0f);
        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioClip openingSound;
        [SerializeField] AudioClip closedSound;

        public override void Interact(Inventory inventory)
        {
            base.Interact(inventory);
            StartCoroutine(OpeningCoroutine());
            //gameObject.SetActive(false);
        }

        public override bool IsInteractable(Inventory inventory)
        {
            bool check = CheckConditionsInInventory(inventory);

            if (!check)
            {
                audioSource.clip = closedSound;
                audioSource.Play();
            }

            return check;
        }

        IEnumerator OpeningCoroutine()
        {
            Debug.Log("Start opening");
            audioSource.clip = openingSound;
            audioSource.Play();
            while (doorWrapper.rotation != rotateToOpen)
            {
                var step = openingSpeed * Time.deltaTime;
                doorWrapper.rotation = Quaternion.RotateTowards(doorWrapper.rotation, rotateToOpen, step);
                Debug.Log("Opening step");
                yield return null;
            }
            Debug.Log("Finished opening");
        }
    }
}