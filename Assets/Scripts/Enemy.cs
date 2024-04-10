using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    public TextMeshProUGUI nextturn;
    public List<string> options;
    public Player Player;
public int ai_energy;
    public GameManager Manager;

    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, 2);
        Debug.Log(options[randomIndex]);
        nextturn.text = options[randomIndex];

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
        
        Manager.enemykill();
    }

    public void enemyturn()
    {

        Player.playerTurn = false;
        Manager.enemyshield = 0;
        
        if (nextturn.text == "attack")
        {
            if (Manager.playershield > 0)
            {
                Manager.playershield -= 5;
            }
            else
            {
                Manager.playerhealth -= 5;
            }

            if (Manager.playershield < 0)
            {
                Manager.playerhealth += Manager.playershield;
                Manager.playershield = 0;
            }
        }

        if (nextturn.text == "defend")
        {
            Manager.enemyshield += 5;
        }

        int randomIndex = Random.Range(0, 2);
        nextturn.text = options[randomIndex];
        Debug.Log("oh'oh");
        Player.SwitchTurn();
    }
}


