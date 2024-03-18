using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;


public class EndTurnButton : MonoBehaviour
{
    public Player player;
    public Button yourButton;
    
    private void Start()
    {
        player = FindObjectOfType<Player>();
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        
        // When the button is clicked, switch the turn
        player.SwitchTurn();
        Debug.Log("button pressed");
    }
}

   



