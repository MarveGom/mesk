using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Jävel!");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Fetkossa");
    }
}