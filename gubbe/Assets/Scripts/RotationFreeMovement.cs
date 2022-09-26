using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFreeMovement : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 2f;

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * walkingSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(Vector3.forward * walkingSpeed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
        }
    }
}