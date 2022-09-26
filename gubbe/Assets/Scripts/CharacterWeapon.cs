using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bool IsPlayerTurn = playerTurn.IsPlayerTurn();
            if (IsPlayerTurn)
            {
                Vector3 force = transform.forward * 700f + transform.up * 300f;
                
                TurnManager.GetInstance().TriggerChangeTurn();
                GameObject newProjectile = Instantiate(projectilePrefab);
                newProjectile.transform.position = shootingStartPosition.position;
                newProjectile.GetComponent<Projectile>().Initialize(force);
            }
        }
    }
}