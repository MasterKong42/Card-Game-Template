using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
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
    public List<GameObject> player_hand = new List<GameObject>();
    public List<GameObject> player_discard_pile = new List<GameObject>();
    public Player player;
    public Enemy enemy;
    public Slider playerhealthbar;
    public Slider enemyhealthbar;
    public bool gameover;
    public GameObject endgamebutton;
    public GameObject endbutton;
    public Canvas canvas;
    public static GameManager instance;
    public int enemiesdefeated;
    public TextMeshProUGUI killcount;

    void Awake()
    {
        // Ensure there's only one instance of GameManager in the scene
        if (instance == null)
        {
            instance = this; // Set the static reference to this instance
            DontDestroyOnLoad(gameObject); // Prevent GameManager from being destroyed when loading new scenes
        }
        else
        {
            // If another instance of GameManager already exists, destroy this one
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(set());
        win.text = " ";
        gameover = false;
        killcount.text = enemiesdefeated + " enemies killed";
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
            gameover = true;
            StartCoroutine(Gameover());
        }

        if (playerhealth < 1 && enemyhealth < 1) 
        {
           win.text = "you tie";
           gameover = true;
           StartCoroutine(Gameover());
        }
        
    }

    public void enemykill()
    {
        
      
        enemiesdefeated += 1;
        killcount.text = enemiesdefeated + " enemies killed";
        enemyhealth = 10;
        enemyshield = 0;
    }

    IEnumerator Gameover()
    {
        yield return new WaitForSeconds(3);
        player_discard_pile.AddRange(player_hand);
        player_hand.Clear();
        player.shuffle();
        enemyhealth = 10;
        enemyshield = 0;
        playerhealth = 10;
        playershield = 0;
        player.player_energy = 0;
        win.text = " ";
        enemiesdefeated = 0;
        killcount.text = enemiesdefeated + " enemies killed";
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
