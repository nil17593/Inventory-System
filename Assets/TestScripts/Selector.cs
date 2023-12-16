using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    int index;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int random = Random.Range(1, 6);
            index = random;
            //EventHandler.onValueSelected(index);
        }
    }
}
