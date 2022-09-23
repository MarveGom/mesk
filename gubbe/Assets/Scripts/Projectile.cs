using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    [SerializeField] private GameObject damageIndicatorPrefab;
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

        {
            GameObject damageIndicator = Instantiate(damageIndicatorPrefab);
            damageIndicator.transform.position = collision.GetContact(0).point;
        }
    }
}