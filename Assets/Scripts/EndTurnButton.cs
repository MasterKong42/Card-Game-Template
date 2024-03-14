using UnityEngine;
using UnityEngine.EventSystems;

public class EndTrunButton : MonoBehaviour, IPointerDownHandler
{
    public Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // When the button is clicked, switch the turn
        player.SwitchTurn();
    }
}

   



