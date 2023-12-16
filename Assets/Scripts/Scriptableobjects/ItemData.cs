using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreaXt.Inventory
{
    /// <summary>
    /// Item data scriptaable object which holds all the items
    /// its heart of this inventory system
    /// </summary>
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/ItemData")]
    public class ItemData : ScriptableObject
    {
        public string fileName;//name of the itemdata file
        public List<Item> items = new List<Item>();
    }
}