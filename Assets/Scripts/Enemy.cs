using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    
    
    public int ai_energy;
    public GameManager Manager;

    // Start is called before the first frame update
    void Start()
    {
        
        enemyturn();

    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.enemyhealth <= 0)
        {
            playerwin();
        } 

    }

    void playerwin()
    {
        Manager.win.text = "You win";
    }

    void enemyturn()
    {
        Manager.enemyshield = 0;
        ai_energy += 3;
        while (Manager.ai_hand.Count<5)
        {
            Aidraw();
            if (Manager.ai_deck.Count <= 0)
                shuffle();
        }

        for (int i = 0; i < 3; i++)
        {
            Ai_playcard(); 
        }
    }

    void Aidraw()
    {
        int randomIndex = Random.Range(0, Manager.ai_deck.Count);
        Manager.ai_hand.Add(Manager.ai_deck[randomIndex]);
        Manager.ai_deck.RemoveAt(randomIndex);
    }

    void Ai_playcard()
    {
        int randomIndex = Random.Range(0, Manager.ai_hand.Count);
        Manager.ai_discard_pile.Add(Manager.ai_hand[randomIndex]);
        Card playedcard = Manager.ai_hand[randomIndex];
        Manager.ai_hand.RemoveAt(randomIndex);
        ai_energy -= 1;
        Card attachedScript = playedcard.GetComponent<Card>();
        if (playedcard.tag == "Attack")
        {
            int damadge = attachedScript.damage;
            if (Manager.playershield > 0)
            {
                Manager.playershield -= damadge;
            }
            else
            {
                Manager.playerhealth -= damadge;
            }

            if (Manager.playershield < 0)
            {
                Manager.playerhealth += Manager.playershield;
            }
            Debug.Log("did "+attachedScript.damage+" damage");
        }

        if (playedcard.tag == "shield")
        {
            Manager.enemyshield += attachedScript.damage;
        }
    }

    void shuffle()
    {
        Manager.ai_deck.AddRange(Manager.ai_discard_pile);
        Manager.ai_discard_pile.Clear();
    }
}


