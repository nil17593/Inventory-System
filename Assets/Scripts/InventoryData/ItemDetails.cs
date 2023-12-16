using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CreaXt.Inventory
{
    public class ItemDetails : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemNameText;
        [SerializeField] private TextMeshProUGUI itemDescriptionText;
        [SerializeField] private TextMeshProUGUI itemWeightText;
        [SerializeField] private Image itemImage;

        private void OnEnable()
        {
            EventHandler.onItemDetailsButtonPressed += PopulateTheData;
        }

        private void OnDisable()
        {
            EventHandler.onItemDetailsButtonPressed -= PopulateTheData;
        }

        //shows the item data with item passed to it
        public void PopulateTheData(Item item)
        {
            if (item != null)
            {
                itemNameText.text = "Name: " + item.itemName;
                itemDescriptionText.text = "Description: " + item.itemDescription;
                itemWeightText.text = "Weight: " + item.itemWeight.ToString("0.00"); // Format the weight as desired
                itemImage.sprite = item.GetImage();
            }
        }
    }
}
