using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CreaXt.Inventory
{
    /// <summary>
    /// InventoryItem class attched on Item prefab
    /// its the iem which is added on the inventory
    /// buttons to remove and add items
    /// </summary>
    
    public class InventoryItem : MonoBehaviour
    {
        [Header("Item references")]
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshProUGUI itemQuantityText;
        [SerializeField] private Button removeButton;
        [SerializeField] private Button addButton;

        #region private fields
        private int currentQuantity;
        private int maxQuantity;
        private Item currentItem;
        #endregion

        //load the initital data
        public void InitData(Item item)
        {
            if (item != null)
            {
                currentItem = item;
                currentQuantity = item.quantity;
                maxQuantity = item.maxQuantity;
                itemImage.sprite = item.GetImage();
                addButton.onClick.AddListener(AddItem);
                removeButton.onClick.AddListener(RemoveItem);
                itemQuantityText.text = currentQuantity.ToString();
            }
            else
            {
                Debug.LogError("Item reference is not set for ItemUI.");
            }
        }

        //add item to inventory triggered when Addbutton pressed 
        private void AddItem()
        {
            if (currentQuantity < maxQuantity)
            {
                currentQuantity++;
                currentItem.quantity++;
                UpdateQuantityUI();
                UIManager.Instance.ShowMessage("Item Added Successfully", true);
            }
            else
            {
                UIManager.Instance.ShowMessage("There is No more Items to Add", false);
            }
        }

        //remove item from inventory
        private void RemoveItem()
        {
            if (currentQuantity > 0)
            {
                currentItem.quantity--;
                currentQuantity--;
                UpdateQuantityUI();
                UIManager.Instance.ShowMessage("Item Removed Successfully", true);
            }
            else
            {
                UIManager.Instance.ShowMessage("There is No more Items to Remove", false);
            }
        }

        //Update Quantity text
        private void UpdateQuantityUI()
        {
            itemQuantityText.text = currentQuantity.ToString();
        }
    }
}