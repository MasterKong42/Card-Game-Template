using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playershield;
    public int enemyshield;
    public int playerhealth;
    public int enemyhealth;
    public TextMeshProUGUI win;
    public static GameManager gm;
    public List<Card> deck = new List<Card>();
    public List<TextMeshProUGUI> player_deck = new List<TextMeshProUGUI>();
    public List<Card> ai_deck = new List<Card>();
    public List<TextMeshProUGUI> player_hand = new List<TextMeshProUGUI>();
    public List<Card> ai_hand = new List<Card>();
    public List<Card> ai_discard_pile = new List<Card>();
    public List<TextMeshProUGUI> player_discard_pile = new List<TextMeshProUGUI>();

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
