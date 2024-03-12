using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrunButton : MonoBehaviour
{
    //public BoxCollider2D;
    public bool PlayerTurn;
    public bool AITurn;
    

    public void Start()
    {
        PlayerTurn = true;
        AITurn = false;
       
    }

    void Update()
    {
        if (PlayerTurn)
        {
            //the code
        }

        if (AITurn)
        {
            
        }
    }

    public void ButtonClicked()
    {
        PlayerTurn = false;
        AITurn = true;
       
    }
}


