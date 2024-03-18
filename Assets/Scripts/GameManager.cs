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
    public List<Card> ai_deck = new List<Card>();
    public List<GameObject> player_hand = new List<GameObject>();
    public List<Card> ai_hand = new List<Card>();
    public List<Card> ai_discard_pile = new List<Card>();
    public List<GameObject> player_discard_pile = new List<GameObject>();
    public Player player;
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
        win.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        Playerhealth.text = "Health " + playerhealth;
        Playershield.text = "Shield " + playershield;
        Playerenergy.text = "Energy " + player.player_energy;
        Aishield.text = "Shield " + enemyshield;
        Aihealth.text = "Health " + enemyhealth;
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
