using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Player Deck and Hand
    public List<CardDisplay> deck = new List<CardDisplay>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    //Points Visual
    public GameObject playerWin1;
    public GameObject playerWin2;
    public GameObject playerWin3;
    public GameObject enemyWin1;
    public GameObject enemyWin2;
    public GameObject enemyWin3;

    public void DrawCard()
    {
        if(deck.Count >= 1)
        {
            CardDisplay randCard = deck[Random.Range(0, deck.Count)];
            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if(availableCardSlots[i] == true)
                {
                    Debug.Log("available + " + randCard);
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
        if(playerWin1 == false)
        {
            playerWin1.SetActive(true);
        }
        else if(playerWin2 == false)
        {
            playerWin2.SetActive(true);
        }
        else if (playerWin3 == false)
        {
            playerWin3.SetActive(true);
            //End match
        }
    }

    public void EnemyWin()
    {
        if (enemyWin1 == false)
        {
            enemyWin1.SetActive(true);
        }
        else if (enemyWin2 == false)
        {
            enemyWin2.SetActive(true);
        }
        else if (enemyWin3 == false)
        {
            enemyWin3.SetActive(true);
            //End match
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Player's starting hand
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        }        
    }

    // Update is called once per frame
    void Update()
    {

    }
}