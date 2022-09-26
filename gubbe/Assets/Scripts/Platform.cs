using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    private void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * _speed, 10) -5, transform.position.y, transform.position.z);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }

}