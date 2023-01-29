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
    public Text effectText;
    public Image art;

    //More Details
    public bool canPlay;
    public int handIndex;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        costText.text = card.cost.ToString();
        attackText.text = card.attack.ToString();
        defenseText.text = card.defense.ToString();
        if (effectText)
        {
            effectText.text = card.effect;
        }
        art.sprite = card.art;
    }

    private void Update()
    {
        canPlay = gm.IsPlayersTurn();
    }

    public void PlayCard()
    {
        if (gm.isPlayersTurn)
        {
            if (card.name == "yuumi")
            {
                gm.DrawCard();
            }                     
            gm.PlayerPlayCard(this);
            gm.availableCardSlots[handIndex] = true;
            gm.PlayerExpendingEnergy(card.cost);
            Destroy(gameObject);
        }
    }
}
