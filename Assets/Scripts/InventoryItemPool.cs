using UnityEngine;
using System.Collections.Generic;

namespace CreaXt.Inventory
{
    public class InventoryItemPool : MonoBehaviour
    {
        public InventoryItem prefab;
        private List<InventoryItem> pool = new List<InventoryItem>();
        public Transform gridTransform;

        public InventoryItem Get()
        {
            InventoryItem item = pool.Find(i => !i.gameObject.activeSelf);
            if (item == null)
            {
                item = Instantiate(prefab, gridTransform);
                pool.Add(item);
            }
            item.gameObject.SetActive(true);
            return item;
        }

        public void ReturnToPool(InventoryItem item)
        {
            item.gameObject.SetActive(false);
        }
    }
}