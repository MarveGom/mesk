using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] public CinemachineVirtualCamera cameraCM1;
    [SerializeField] public CinemachineVirtualCamera cameraCM2;

    private int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;
    private PlayerTurn currentPlayer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
            playerOne.SetPlayerTurn(1);
            playerTwo.SetPlayerTurn(2);
        }
    }

    private void Update()
    {
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if(turnDelay > timeBetweenTurns)
            {
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }

        if (GameObject.FindWithTag ("Player1") == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (GameObject.FindWithTag("Player2") == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        {
            return false;
        }

        return index == currentPlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    private void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
            cameraCM1.Priority -= 5;
            cameraCM2.Priority += 5;
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
            cameraCM1.Priority += 5;
            cameraCM2.Priority -= 5;
        }
    }
}