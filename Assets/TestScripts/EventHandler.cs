using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreaXt.Inventory
{
    public static class EventHandler
    {
        public delegate void OnValueSelected(int value);
        public static OnValueSelected onValueSelected;
        public delegate void OnItemDetailsButtonPressed(Item item);
        public static OnItemDetailsButtonPressed onItemDetailsButtonPressed;
    }
}
