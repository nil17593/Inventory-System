using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Collections;
using System.IO;
using System;

namespace CreaXt.Inventory
{
    /// <summary>
    /// Inventory manager class 
    /// handles all the inventory related logic
    /// adding items in inventory and save in JSON
    /// removing items from inventory and remove from JSON
    /// show filtered items
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private ItemData itemData;
        [Header("UI settings for the Inventory")]
        [SerializeField] private Transform gridContainer;
        [SerializeField] private InventoryItem inventoryItemPrefab;
        [SerializeField] private ItemDetails itemDetails;
        [SerializeField] private TMP_Dropdown dropdown;

        #region private lists
        private List<Item> filteredInventory;
        private List<Item> items;
        #endregion

        private void Awake()
        {
            filteredInventory = new List<Item>();
            items = new List<Item>();
            dropdown.onValueChanged.AddListener(FilterInventory);
            items = itemData.items;
        }

        public void OnSpaceClicked()
        {
            Item newItem = new Item();
            newItem.itemID = 10;
            newItem.itemDescription = "SSSSSS";
            newItem.itemWeight = 5f;
            newItem.quantity = 5;
            newItem.maxQuantity = 15;
            newItem.itemType = Item.ItemType.knife;
            newItem.GetImage();
            itemData.items.Add(newItem);
        }

        private void Start()
        {
            PopulateInventoryData();
        }

        private void OnDestroy()
        {
            JsonManager.Instance.SaveInventory(itemData);
        }

        //populate the inventory data from Json if no saved json data is there then set premade data
        private void PopulateInventoryData()
        {
            ItemData itemData = JsonManager.Instance.LoadInventory();
            if (itemData != null)
            {
                this.itemData = itemData;
                this.items = itemData.items;
                foreach (Item item in items)
                {
                    InventoryItem itemTemplate = Instantiate(inventoryItemPrefab, gridContainer);
                    itemTemplate.InitData(item);
                    Button itemButton = itemTemplate.GetComponent<Button>();
                    itemButton.onClick.AddListener(() => ShowItemDetails(item));
                }
            }
            else
            {
                foreach (Item item in items)
                {
                    InventoryItem itemTemplate = Instantiate(inventoryItemPrefab, gridContainer);
                    itemTemplate.InitData(item);
                    Button itemButton = itemTemplate.GetComponent<Button>();
                    itemButton.onClick.AddListener(() => ShowItemDetails(item));
                }
            }
        }
  
        // Display item details when an item is clicked
        private void ShowItemDetails(Item item)
        {
            if (!itemDetails.gameObject.activeSelf)
            {
                itemDetails.gameObject.SetActive(true);
            }
            //itemDetails.PopulateTheData(item);
            EventHandler.onItemDetailsButtonPressed(item);
        }

        //We can implement pooling here
        public void FilterInventory(int filterIndex)
        {
            // Clear the filtered inventory
            filteredInventory.Clear();

            // Populate the filtered inventory based on the selected filter
            foreach (Item item in items)
            {
                if (filterIndex == 0 || item.itemType == (Item.ItemType)filterIndex)
                {
                    filteredInventory.Add(item);
                    Debug.Log("FF= " + filteredInventory.Count);
                    if (filterIndex == 0)
                    {
                        UIManager.Instance.ChangeItemFilterTitle("all items");
                    }
                    else
                    {
                        UIManager.Instance.ChangeItemFilterTitle(item.itemType.ToString());
                    }
                }
            }

            // Clear the existing items in the grid
            foreach (Transform child in gridContainer)
            {
                Destroy(child.gameObject);
            }

            // Populate the grid with filtered items
            foreach (Item item in filteredInventory)
            {
                InventoryItem itemTemplate = Instantiate(inventoryItemPrefab, gridContainer);
                itemTemplate.InitData(item);
                Button itemButton = itemTemplate.GetComponent<Button>();
                itemButton.onClick.AddListener(() => ShowItemDetails(item));
            }
        }

        //triggered when Save Button Clicked
        public void OnClickSaveDataButton()
        {
            JsonManager.Instance.SaveInventory(itemData);
            UIManager.Instance.ShowMessage("Data saved Successfully", true);
        }
    }
}