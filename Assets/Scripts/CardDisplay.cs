using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    //GM
    public GameManager gm;

    //Card info
    public Card card;
    public Text nameText;
    public Text costText;
    public Text attackText;
    public Text defenseText;
    public Image art;

    //More Details
    public bool isInHand;
    public bool canPlay;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        costText.text = card.cost.ToString();
        attackText.text = card.attack.ToString();
        defenseText.text = card.defense.ToString();
        art.sprite = card.art;        
    }

    private void Update()
    {
        canPlay = gm.IsPlayersTurn();
    }

    public void PlayCard()
    {
        Debug.Log("Played the card");
        if (isInHand)
        {
            gm.PlayerExpendingEnergy(card.cost);
        }
    }
}
