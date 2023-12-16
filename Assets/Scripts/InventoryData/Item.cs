using UnityEngine;


namespace CreaXt.Inventory
{
    /// <summary>
    /// Item serializable class
    /// holds all the item data
    /// </summary>
    
    [System.Serializable]
    public class Item
    {
        public int itemID;
        public ItemType itemType;
        public string itemName;
        public string itemDescription;
        public float itemWeight;
        public string imageName;
        public int quantity;
        public int maxQuantity;

        //returns the image with given path
        public Sprite GetImage()
        {
            Sprite loadedSprite = Resources.Load<Sprite>(imageName);

            // Check if the loadedSprite is null before returning it.
            if (loadedSprite == null)
            {
                Debug.LogWarning("Image asset is null or not found for path: " + imageName);
            }

            return loadedSprite;
        }

        //Enum to define item type
        public enum ItemType
        {
            None,
            Sword,
            knife
        }

    }
}