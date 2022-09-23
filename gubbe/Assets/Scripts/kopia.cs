using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kopia : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    private bool isActive;

    public void Initialize()
    {
        isActive = true;
        projectileBody.AddForce(transform.forward * 700f + transform.up * 300f);
    }

    void Update()
    {
        if (isActive)
        {
            //projectileBody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;
        DestructionFree destruction = collisionObject.GetComponent<DestructionFree>();
        if (destruction == null)
            Destroy(collisionObject);
    }
}