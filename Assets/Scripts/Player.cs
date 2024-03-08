using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int player_energy;
    
    public GameManager Manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playcard(GameObject Card)
    {
        Debug.Log("card played"+Card.name);
    }
}
