using TMPro;
using UnityEngine;
using System.Collections;

namespace CreaXt.Inventory
{
    /// <summary>
    /// UI manager class 
    /// show the messages related to inventory
    /// </summary>
    public class UIManager : MonoGenericSingletone<UIManager>
    {
        [Header("UI references")]
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private TextMeshProUGUI itemFilterTitle;


        protected override void Awake()
        {
            base.Awake();
        }

        //coroutine for show in game messages
        public IEnumerator ShowMessageCoroutine(string _message, bool success)
        {
            if (success)
            {
                messageText.color = Color.green;
            }
            else
            {
                messageText.color = Color.red;
            }
            messageText.gameObject.SetActive(true);
            messageText.text = _message;
            yield return new WaitForSeconds(1f);
            messageText.gameObject.SetActive(false);
        }

        //show in game messages
        public void ShowMessage(string _message, bool success)
        {
            StartCoroutine(ShowMessageCoroutine(_message, success));
        }

        //change filter title
        public void ChangeItemFilterTitle(string title)
        {
            itemFilterTitle.text = title;
        }
    }
}