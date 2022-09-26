using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sjot : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Debug.LogError("Pew");
    }
}