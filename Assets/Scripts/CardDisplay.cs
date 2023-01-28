using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text nameText;
    public Text costText;
    public Text attackText;
    public Text defenseText;

    public Image art;

    private void Start()
    {
        costText.text = card.cost.ToString();
        attackText.text = card.attack.ToString();
        defenseText.text = card.defense.ToString();
        art.sprite = card.art;        
    }
}
