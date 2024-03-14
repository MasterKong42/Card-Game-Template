using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Card card;
    public int player_energy;
    public Card_data data;
    public bool isPlayerTurn = true;
    public GameManager Manager;
    public bool boosted;
    public int effectAmount;
    public int meteor;

    // Start is called before the first frame update
    void Start()
    {
        boosted = false;
        player_energy = 6;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playerturn()
    {
        Manager.playershield = 0;
        player_energy += 3;
        while (Manager.player_hand.Count<5)
        {
            Playerdraw();
            if (Manager.ai_deck.Count <= 0)
                shuffle();
        }
        
    }
    
    public void SwitchTurn()
    {
        isPlayerTurn = !isPlayerTurn; // Toggle between player's turn and AI's turn
        
        if (!isPlayerTurn)
        {
            // Call a method to execute AI's turn
            //AIPlayer.Instance.ExecuteTurn();
        }
        else
        {
            playerturn();
           
        }
    }

    void Playerdraw()
    {
        int randomIndex = Random.Range(0, Manager.player_deck.Count);
        Manager.player_hand.Add(Manager.player_deck[randomIndex]);
        Manager.player_deck.RemoveAt(randomIndex);
    }
    void shuffle()
    {
        Manager.player_deck.AddRange(Manager.player_discard_pile);
        Manager.player_discard_pile.Clear();
    }

    public void playcard(TextMeshProUGUI Card)
    {
        card = FindObjectOfType<Card>();
        data = card.data;
        Debug.Log("Card Name: " + data.card_name);
        Debug.Log("Description: " + data.description);
        Debug.Log("Health: " + data.health);
        Debug.Log("Cost: " + data.cost);
        Debug.Log("Damage: " + data.damage);
        if (player_energy < data.cost)
        {
            return;
        }
        if (player_energy >= data.cost)
        {
            player_energy -= data.cost;
        }
        effectAmount = data.damage;
        if (boosted)
        {
            effectAmount *= 2;
            boosted = false;
        }

        if (Card.CompareTag("Attack"))
        {
            if (Manager.playershield > 0)
            {
                Manager.enemyshield -= effectAmount;
            }
            else
            {
                Manager.enemyhealth -= effectAmount;
            }

            if (Manager.enemyshield < 0)
            {
                Manager.enemyhealth += Manager.enemyshield;
                Manager.enemyshield = 0;
            }
            Debug.Log("did "+effectAmount+" damage");
        }

        if (Card.CompareTag("Sheild"))
        {
            Manager.playershield += effectAmount;
        }

        //if (Card.CompareTag("Peirce"))
       //{
        //    Manager.enemyhealth -= effectAmount;
        //}

        if (Card.CompareTag("Heal"))
        {
            Manager.playerhealth += effectAmount;
        }

        if (Card.CompareTag("Meteor"))
        {
            Manager.enemyhealth -= effectAmount;
            Debug.Log("did "+effectAmount+" damage");
            meteor = Mathf.FloorToInt(effectAmount/2);
            Manager.playerhealth -= meteor;
            Debug.Log("did "+meteor+" damage to player");

        }

        Manager.player_hand.Remove(Card);
        Manager.player_discard_pile.Add(Card);
        Destroy(Card);
        
    }

}

