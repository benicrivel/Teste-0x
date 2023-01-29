using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Deck, Hand
    public List<Card> playerDeck = new List<Card>();
    public List<Card> playerHand = new List<Card>();
    public List<Card> enemyDeck = new List<Card>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    //Boards Count
    public Transform[] playerBoardPos;
    public bool[] availableCardSlotsPlayerBoard;
    public Transform[] enemyBoardPos;
    public bool[] availableCardSlotsEnemyBoard;
    public List<Card> playerBoard = new List<Card>();
    public List<Card> enemyBoard = new List<Card>();

    //Points Visual
    public int playerWins;
    public int enemyWins;
    public GameObject playerWin1;
    public GameObject playerWin2;
    public GameObject playerWin3;
    public GameObject enemyWin1;
    public GameObject enemyWin2;
    public GameObject enemyWin3;
    public GameObject tag;

    //Board Control
    public bool isPlayersTurn;
    public bool canEnemyPlay;

    //Energy Meter
    public int energy;
    public Text energyText;

    //Turn counter
    public int cardsPlayed;
    public Text cardsPlayedText;

    //Animation
    public float timeToWait;
    public GameObject fire;
    public GameObject crown;

    //End Game
    public GameObject winMenu;
    public GameObject loseMenu;

    //Test
    public Card cardTest;
    public CardDisplay cdt;

    public void DrawCard()
    {
        if (playerDeck.Count >= 1)
        {
            Card randCard = playerDeck[Random.Range(0, playerDeck.Count)];
            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if (availableCardSlots[i] == true)
                {
                    CardDisplay a = Instantiate(cdt, cardSlots[i]);
                    a.card = randCard;
                    a.handIndex = i;
                    availableCardSlots[i] = false;
                    playerHand.Add(randCard);
                    playerDeck.Remove(randCard);
                    return;
                }
            }
        }
    }

    public void PlayerPlayCard(Card cd)
    {
        for (int i = 0; i < availableCardSlotsPlayerBoard.Length; i++)
        {
            if (availableCardSlotsPlayerBoard[i] == true)
            {
                CardDisplay a = Instantiate(cdt, playerBoardPos[i]);
                a.card = cd;
                a.gameObject.AddComponent<BornToDie>();
                availableCardSlotsPlayerBoard[i] = false;
                playerBoard.Add(a.card);
                //Make the hand spot free again
                for (int o = 0; o > playerHand.Count; o++)
                {
                    if (playerHand[o].cardName == a.card.cardName)
                    {
                        availableCardSlots[o] = true;
                    }
                }
                playerHand.Remove(a.card);
                return;
            }
        }
    }      

    public void EnemyPlayCard()
    {
        Debug.Log("Enemy played a card");
        if (enemyDeck.Count >= 1 && canEnemyPlay)
        {
            Card randCard = enemyDeck[Random.Range(0, enemyDeck.Count)];
            for (int i = 0; i < availableCardSlotsEnemyBoard.Length; i++)
            {
                if (availableCardSlotsEnemyBoard[i] == true)
                {
                    CardDisplay a = Instantiate(cdt, enemyBoardPos[i]);
                    a.card = randCard;
                    a.gameObject.AddComponent<BornToDie>();
                    availableCardSlotsEnemyBoard[i] = false;
                    int randCardCost = a.card.cost;
                    enemyBoard.Add(a.card);
                    enemyDeck.Remove(randCard);
                    PlayerExpendingEnergy(-randCardCost);
                    return;
                }
            }
        }
        if (energy < 0)
        {
            EnemyPlayCard();
        }
    }

    public void RefreshText()
    {
        energyText.text = ("" + energy);
        cardsPlayedText.text = ("" + cardsPlayed);
    }

    public void PlayerWin()
    {
        playerWins++;
        switch (playerWins) 
        {
            case 1:
                playerWin1.SetActive(true);
                break;
            case 2:
                playerWin2.SetActive(true);
                break;
            case 3:
                playerWin3.SetActive(true);
                //End Game
                winMenu.SetActive(true);
                break;
        }

        //Spawn Crown on Player Cards
        for (int i = 0; i < playerBoard.Count; i++)
        {
            GameObject go = Instantiate(crown, playerBoardPos[i]);
        }

        //Spawn Fire on Enemy Cards
        for (int i = 0; i < enemyBoard.Count; i++)
        {
            GameObject go = Instantiate(fire, enemyBoardPos[i]);
        }
    }

    public void EnemyWin()
    {
        enemyWins++;
        switch (enemyWins)
        {
            case 1:
                enemyWin1.SetActive(true);
                break;
            case 2:
                enemyWin2.SetActive(true);
                break;
            case 3:
                enemyWin3.SetActive(true);
                //End Game
                loseMenu.SetActive(true);
                break;
        }

        //Spawn Fire on Player Cards
        for (int i = 0; i < playerBoard.Count; i++)
        {
            GameObject go = Instantiate(fire, playerBoardPos[i]);
        }

        //Spawn Crown on Enemy Cards
        for (int i = 0; i < enemyBoard.Count; i++)
        {
            GameObject go = Instantiate(crown, enemyBoardPos[i]);
        }
    }

    public void EndTurn()
    {
        if (isPlayersTurn)
        {
            //Give opponent 3 energy
            int a = energy + 3;
            PlayerExpendingEnergy(a);
        }
    }

    public void PlayerExpendingEnergy(int a)
    {
        canEnemyPlay = false;
        cardsPlayed++;
        energy -= a;
        MoveTag(a);
        RefreshText();
        SwitchPlayed();
        TurnCheck();
    }

    //Energy Meter Movement
    public void MoveTag(int a)
    {
        float i = tag.transform.position.y + (a * 25f);
        tag.transform.position = new Vector3(tag.transform.position.x, i , tag.transform.position.z);
    }

    public void SwitchPlayed()
    {
        switch (cardsPlayed)
        {
            case 4:
                Debug.Log("Case 4");
                Rumble();
                break;
            case 8:
                Rumble();
                break;
            case 12:
                Rumble();
                break;
            case 16:
                Rumble();
                break;
            case 20:
                Rumble();
                break;
            case 24:
                Rumble();
                break;
            case 28:
                Rumble();
                break;
            case 32:
                Rumble();
                break;
            case 36:
                Rumble();
                break;
            case 40:
                Rumble();
                break;
        }
    }

    public void DrawOpeningHand()
    {
        //Player's starting hand
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        }
    }

    public bool IsPlayersTurn()
    {
        return isPlayersTurn;
    }

    public void TurnCheck()
    {
        Debug.Log("Turn Check");
        if (energy >= 0)
        {
            isPlayersTurn = true;
            canEnemyPlay = false;
            DrawCard();
        }
        else
        {
            isPlayersTurn = false;
            canEnemyPlay = true;
            EnemyPlayCard();
        }
    }

    public void CheckBoards()
    {
        Debug.Log("Board Check");

        int playerPower = 0;
        int enemyPower = 0;

        playerPower = CheckPlayerBoard();

        enemyPower = CheckEnemyBoard();

        //animations

        if(playerPower > enemyPower)
        {
            PlayerWin();
            playerPower = 0;
            enemyPower = 0;
        }
        else if(playerPower < enemyPower)
        {
            EnemyWin();
            playerPower = 0;
            enemyPower = 0;
        }
        canEnemyPlay = false;
        StartCoroutine(Wait());
        StartCoroutine(ResetBoards2());
    }

    IEnumerator Wait()
    {
        canEnemyPlay = false;
        isPlayersTurn = false;
        yield return new WaitForSecondsRealtime(timeToWait);
    }

    IEnumerator ResetBoards2()
    {
        Debug.Log("Reset Boards");
        yield return new WaitForSecondsRealtime(timeToWait);
        playerBoard.Clear();
        for (int i = 0; i < availableCardSlotsPlayerBoard.Length; i++)
        {
            availableCardSlotsPlayerBoard[i] = true;
        }
        enemyBoard.Clear();
        for (int i = 0; i < availableCardSlotsEnemyBoard.Length; i++)
        {
            availableCardSlotsEnemyBoard[i] = true;
        }
        foreach (BornToDie c in FindObjectsOfType<BornToDie>())
        {
            Destroy(c.gameObject);
        }
    }

    public int CheckPlayerBoard()
    {
        int a = 0;

        for (int i = 0; i < playerBoard.Count; i++)
        {
            a += playerBoard[i].attack;
            Debug.Log("PlayerPower: " + a);
        }      

        return a;
    }

    public int CheckEnemyBoard()
    {
        int a = 0;

        for (int i = 0; i < enemyBoard.Count; i++)
        {
            a += enemyBoard[i].attack;
            Debug.Log("EnemyPower: " + a);
        }      

        return a;
    }

    public void ResetBoards()
    {
        playerBoard.Clear();
        for(int i = 0; i < availableCardSlotsPlayerBoard.Length; i++)
        {
            availableCardSlotsPlayerBoard[i] = true;
        }
        enemyBoard.Clear();
        for (int i = 0; i < availableCardSlotsEnemyBoard.Length; i++)
        {
            availableCardSlotsEnemyBoard[i] = true;
            //enemyBoardPos[i].
        }        
        foreach (BornToDie c in FindObjectsOfType<BornToDie>())
        {
            Destroy(c.gameObject);
        }
    }

    public void Rumble()
    {
        isPlayersTurn = false;
        canEnemyPlay = false;
        CheckBoards();
    }

    void Start()
    {
        playerWins = enemyWins = 0;
        DrawOpeningHand();
        TurnCheck();
    }
}