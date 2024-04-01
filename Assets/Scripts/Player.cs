using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{

    public Enemy Enemy;
    public GameObject playedcard;
    public int player_energy;
    public Card data;
    public bool isPlayerTurn = true;
    public GameManager Manager;
    public bool boosted;
    public int effectAmount;
    public int meteor;
    public bool playerTurn;
    public Canvas canvas;
    public Transform randomspot;

    public GameObject drawncard;
    // Start is called before the first frame update
    void Start()
    {
        Manager.playerhealth = 10;
        boosted = false;
        player_energy = 0;
        playerturn();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playerturn()
    {
        Debug.Log("before"+ playerTurn);
        playerTurn = true;
        Debug.Log("after"+playerTurn);
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
            Debug.Log("a");
            // Call a method to execute AI's turn
            Enemy.enemyturn();
            
        }
        else
        {
            Debug.Log("b");
            playerturn();
            
        }
    }

    void Playerdraw()
    {
        if (Manager.player_deck.Count != 0)
        {
            randomspot.position = new Vector2(Random.Range(40, 1100), Random.Range(60, 300));
            int randomIndex = Random.Range(0, Manager.player_deck.Count);
            Debug.Log(randomspot.position);
            drawncard = Manager.player_deck[randomIndex];
            Manager.player_deck[randomIndex].SetActive(true);
            drawncard.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
            drawncard.transform.parent = canvas.transform;
            drawncard.transform.position = randomspot.position;
            Manager.player_hand.Add(Manager.player_deck[randomIndex]);
            Manager.player_deck.RemoveAt(randomIndex);
        }
        else shuffle();
    }
    void shuffle()
    {
        Manager.player_deck.AddRange(Manager.player_discard_pile);
        Manager.player_discard_pile.Clear();
    }

    public void playcard(GameObject  pCard)
    {
        if (playerTurn)
        {
            
            Manager.player_discard_pile.Add(pCard);
            Manager.player_hand.Remove(pCard);
           
            playedcard = pCard.transform.GetChild(0).gameObject;

            
            data= playedcard.GetComponent<Card>();
            
            Debug.Log("Card Name: " + data.card_name);
            Debug.Log("Description: " + data.description);
            Debug.Log("Health: " + data.health);
            Debug.Log("Cost: " + data.cost);
            Debug.Log("Effect: " + data.damage);
            if (player_energy < data.cost)
            {
                randomspot.position = new Vector2(Random.Range(40, 1100), Random.Range(60, 300));
                pCard.transform.position = randomspot.position;
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

            if (pCard.CompareTag("Attack"))
            {
                if (Manager.enemyshield > 0)
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

                Debug.Log("did " + effectAmount + " damage");
            }

            if (pCard.CompareTag("Sheild"))
            {
                Manager.playershield += effectAmount;
            }

            if (pCard.CompareTag("Peirce"))
            {
                Manager.enemyhealth -= effectAmount;
            }

            if (pCard.CompareTag("Heal"))
            {
                Manager.playerhealth += effectAmount;
            }

            if (pCard.CompareTag("Meteor"))
            {
                if (Manager.enemyshield > 0)
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
                Debug.Log("did " + effectAmount + " damage");
                meteor = Mathf.FloorToInt(effectAmount / 2);
                if (Manager.playershield > 0)
                {
                    Manager.playershield -= meteor;
                }
                else
                {
                    Manager.playerhealth -= meteor;
                }

                if (Manager.playershield < 0)
                {
                    Manager.playerhealth += Manager.playershield;
                    Manager.playershield = 0;
                }
                Manager.playerhealth -= meteor;
                Debug.Log("did " + meteor + " damage to player");

            }

            if (pCard.CompareTag("Multiply"))
            {
                boosted = true;
            }

            Manager.player_hand.Remove(pCard);
            
            pCard.SetActive(false);
        }
    }

}

