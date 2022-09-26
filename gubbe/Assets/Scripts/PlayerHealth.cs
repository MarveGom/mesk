using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 2;

    private void Start()
    {
    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}