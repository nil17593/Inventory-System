using UnityEngine;
using System.IO;

namespace CreaXt.Inventory
{
    /// <summary>
    /// Json manager class handles all the JSON operations
    /// saving loading the data in JSON
    /// </summary>

    public class JsonManager : MonoGenericSingletone<JsonManager>
    {
        [SerializeField] private ItemData itemData; // Reference to the player's inventory Scriptable Object
        [SerializeField] private string savePath;

        protected override void Awake()
        {
            base.Awake();
            savePath = Application.persistentDataPath + "/inventory.json";
        }

        //Save the inventory data in JSON
        public void SaveInventory(ItemData itemData)
        {
            try
            {
                // Save the Inventory as JSON
                string serializedData = SerializeScriptableObject(itemData);
                File.WriteAllText(savePath, serializedData);
                Debug.Log("SAved= " + serializedData);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Serialization Error: " + e.Message);
            }

        }
        
        //Load inventory data from JSON
        public ItemData LoadInventory()
        {
            try
            {
                if (File.Exists(savePath))
                {
                    string json = File.ReadAllText(savePath);
                    itemData = DeserializeJsonToScriptableObject<ItemData>(json);
                    return itemData;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Deserialization Error: " + e.Message);
            }
            return null;
        }

        //serialize the scriptable object into JSON
        private string SerializeScriptableObject(ScriptableObject scriptableObject)
        {
            // Serialize the ScriptableObject to JSON
            return JsonUtility.ToJson(scriptableObject);
        }

        //deserialize the Scriptable object
        private T DeserializeJsonToScriptableObject<T>(string json) where T : ScriptableObject
        {
            T deserializedObject = CreateInstance<T>();
            JsonUtility.FromJsonOverwrite(json, deserializedObject);
            return deserializedObject;
        }

        //Creates the instance of passed scriptable object
        private static T CreateInstance<T>() where T : ScriptableObject
        {
            T instance = ScriptableObject.CreateInstance<T>();
            return instance;
        }
    }
}

