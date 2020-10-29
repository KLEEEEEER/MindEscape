using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DifferentPlanetSession.Core.Player.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        List<InventoryItem> items = new List<InventoryItem>();

        public InventoryItem HasItem(InventoryItem usingItem)
        {
            return items.Where(item => item.GetType().ToString() == usingItem.GetType().ToString()).FirstOrDefault();
        }

        public InventoryItem HasItem(InventoryItemSO usingItem)
        {
            return items.Where(item => item.inventoryItemToUse == usingItem).FirstOrDefault();
        }

        public void AddItem(InventoryItem item)
        {
            items.Add(item);
        }

        public void UseItem(InventoryItem usingItem)
        {
            InventoryItem foundItem = HasItem(usingItem);
            if (foundItem != null)
            {
                foundItem.Use();
            }
        }

        public void RemoveItem(InventoryItemSO usingItem)
        {
            InventoryItem foundItem = items.Where(item => item.inventoryItemToUse == usingItem).FirstOrDefault();
            items.Remove(foundItem);
        }

        public void DebugItems()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(items.Count);
            stringBuilder.Append(" items in inventory: ");
            for (int i = 0; i < items.Count; i++)
            {
                stringBuilder.Append(items[i].itemName);
                if (i != items.Count - 1)
                    stringBuilder.Append(", ");
            }
            Debug.Log(stringBuilder.ToString());
        }
    }
}