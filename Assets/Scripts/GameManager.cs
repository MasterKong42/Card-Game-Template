using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Playerhealth;
    public TextMeshProUGUI Playershield;
    public TextMeshProUGUI Playerenergy;
    public TextMeshProUGUI Aishield;
    public TextMeshProUGUI Aihealth;
    public int playershield;
    public int enemyshield;
    public int playerhealth;
    public int enemyhealth;
    public TextMeshProUGUI win;
    public static GameManager gm;
    public List<Card> deck = new List<Card>();
    public List<GameObject> player_deck = new List<GameObject>();
    public List<GameObject> ai_deck = new List<GameObject>();
    public List<GameObject> player_hand = new List<GameObject>();
    public List<GameObject> ai_hand = new List<GameObject>();
    public List<GameObject> ai_discard_pile = new List<GameObject>();
    public List<GameObject> player_discard_pile = new List<GameObject>();
    public Player player;
    public Slider playerhealthbar;
    public Slider enemyhealthbar;
    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(set());
        win.text = " ";
    }

    IEnumerator set()
    {
        yield return new WaitForSeconds(.01f);
        win.text = " ";
    }

    
    

    // Update is called once per frame
    void Update()
    {
        playerhealthbar.value = playerhealth;
        enemyhealthbar.value = enemyhealth;
        Playerhealth.text = "Health " + playerhealth;
        Playershield.text = "Shield " + playershield;
        Playerenergy.text = "Energy " + player.player_energy;
        Aishield.text = "Shield " + enemyshield;
        Aihealth.text = "Health " + enemyhealth;
        if (playerhealth < 1 && enemyhealth > 1)
        {
            win.text = "you lose";
        }

        if (playerhealth < 1 && enemyhealth < 1) 
        {
           win.text = "you tie";
        }
        
    }

    void Deal()
    {

    }

    void Shuffle()
    {

    }

    void AI_Turn()
    {

    }



    
}
