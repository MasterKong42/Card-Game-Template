using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{


    public Player Player;
public int ai_energy;
    public GameManager Manager;

    // Start is called before the first frame update
    void Start()
    {

        Manager.enemyhealth = 10;

    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.enemyhealth <= 0 && Manager.playerhealth> 0)
        {
            playerwin();
        } 

    }

    void playerwin()
    {
        Manager.win.text = "You win";
        Manager.endgame();
    }

    public void enemyturn()
    {
        
        Player.playerTurn = false;
        Manager.enemyshield = 0;
        ai_energy += 3;
        while (Manager.ai_hand.Count<5)
        {
            Aidraw();
            if (Manager.ai_deck.Count <= 0)
                shuffle();
        }

        
        StartCoroutine(Ai_playcard());
        
        Debug.Log("d");
        StartCoroutine(delayfortesting());
    }

    IEnumerator delayfortesting()
    {
        yield return new WaitForSeconds(3);
        Player.SwitchTurn();
    }

    void Aidraw()
    {
        int randomIndex = Random.Range(0, Manager.ai_deck.Count);
        Manager.ai_hand.Add(Manager.ai_deck[randomIndex]);
        Manager.ai_deck.RemoveAt(randomIndex);
    }

    IEnumerator Ai_playcard()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1f);
            int randomIndex = Random.Range(0, Manager.ai_hand.Count);
            Manager.ai_discard_pile.Add(Manager.ai_hand[randomIndex]);
            GameObject playedcard = Manager.ai_hand[randomIndex];
            Manager.ai_hand.RemoveAt(randomIndex);
            ai_energy -= 1;
            Card attachedScript = playedcard.GetComponent<Card>();
            if (playedcard.tag == "Attack")
            {
                
                if (Manager.playershield > 0)
                {
                    Manager.playershield -= attachedScript.damage;
                }
                else
                {
                    Manager.playerhealth -= attachedScript.damage;
                }

                if (Manager.playershield < 0)
                {
                    Manager.playerhealth += Manager.playershield;
                }
                Debug.Log("did "+attachedScript.damage+" damage");
            }

            if (playedcard.tag == "Heal")
            {
                Manager.enemyhealth += attachedScript.damage;
            }

            else
            {
                Manager.enemyshield += attachedScript.damage;
                Debug.Log("added"+attachedScript.damage+"shield");
            } 
        }
        
    }

    void shuffle()
    {
        Manager.ai_deck.AddRange(Manager.ai_discard_pile);
        Manager.ai_discard_pile.Clear();
    }
}


