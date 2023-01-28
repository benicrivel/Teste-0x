using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Deck, Hand and Boards
    public List<CardDisplay> deck = new List<CardDisplay>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;
    public Transform[] playerBoard;
    public bool[] availableCardSlotsPlayerBoard;
    public Transform[] enemyBoard;
    public bool[] availableCardSlotsEnemyBoard;

    //Points Visual
    public int playerWins;
    public int enemyWins;
    public GameObject playerWin1;
    public GameObject playerWin2;
    public GameObject playerWin3;
    public GameObject enemyWin1;
    public GameObject enemyWin2;
    public GameObject enemyWin3;

    //Board Control
    public bool isPlayersTurn;

    //Energy Meter
    public int energy;


    public void DrawCard()
    {
        if(deck.Count >= 1)
        {
            CardDisplay randCard = deck[Random.Range(0, deck.Count)];
            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if(availableCardSlots[i] == true)
                {
                    Instantiate(randCard, cardSlots[i]);
                    availableCardSlots[i] = false;
                    deck.Remove(randCard);
                    return;
                }
            }
        }
    }

    public void PlayerWin()
    {
        playerWins++;
        switch (playerWins) 
        {
            case 0:
                playerWin1.SetActive(false);
                playerWin2.SetActive(false);
                playerWin3.SetActive(false);
                break;
            case 1:
                playerWin1.SetActive(true);
                playerWin2.SetActive(false);
                playerWin3.SetActive(false);
                break;
            case 2:
                playerWin1.SetActive(true);
                playerWin2.SetActive(true);
                playerWin3.SetActive(false);
                break;
            case 3:
                playerWin1.SetActive(true);
                playerWin2.SetActive(true);
                playerWin3.SetActive(true);
                //End Game
                break;
        }
    }

    public void EnemyWin()
    {
        enemyWins++;
        switch (enemyWins)
        {
            case 0:
                enemyWin1.SetActive(false);
                enemyWin2.SetActive(false);
                enemyWin3.SetActive(false);
                break;
            case 1:
                enemyWin1.SetActive(true);
                enemyWin2.SetActive(false);
                enemyWin3.SetActive(false);
                break;
            case 2:
                enemyWin1.SetActive(true);
                enemyWin2.SetActive(true);
                enemyWin3.SetActive(false);
                break;
            case 3:
                enemyWin1.SetActive(true);
                enemyWin2.SetActive(true);
                enemyWin3.SetActive(true);
                //End Game
                break;

        }
    }

    public void EndTurn()
    {
        //Give opponent 3 energy
    }

    public void PlayerExpendingEnergy(int a)
    {
        energy -= a;
        Debug.Log("Energy: " + energy);
    }

    public bool IsPlayersTurn()
    {
        return isPlayersTurn;
    }

    void Start()
    {
        playerWins = enemyWins = 0;
        //Player's starting hand
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        }        
    }

    void Update()
    {
        //Make it less memory consuming
        if(energy >= 0)
        {
            isPlayersTurn = true;
        }
        else
        {
            isPlayersTurn = false;
        }
    }
}