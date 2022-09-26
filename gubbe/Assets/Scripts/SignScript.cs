using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignScript : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        NewMethod();
    }

    private void NewMethod()
    {
        Destroy(gameObject, 7);
    }
}