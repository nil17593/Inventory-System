using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    [SerializeField] private GameObject gameObjects;


    //private void Start()
    //{
    //    EventHandler.onValueSelected += React;
    //}

    //private void OnDisable()
    //{
    //    EventHandler.onValueSelected -= React;

    //}


    void React(int value)
    {
        Debug.Log(value);
    }

}
