using UnityEngine;
using System.Collections.Generic;

public class AIPlayer : MonoBehaviour
{
    public List<Card> hand = new List<Card>(); // Assuming you have a Card class representing the cards
    
    public void ExecuteTurn()
    {
        if (hand.Count > 0)
        {
            // Select a random card from the AI's hand
            int randomIndex = Random.Range(0, hand.Count);
            Card cardToPlay = hand[randomIndex];

            // Perform some action with the card (for example, play it)
            PlayCard(cardToPlay);

            // Remove the card from the AI's hand after playing
            hand.RemoveAt(randomIndex);
        }
        else
        {
            Debug.Log("AI has no cards to play!");
        }
    }

    void PlayCard(Card card)
    {
        // Implement the logic to play the selected card
        Debug.Log("AI plays card: " + card.name);
        // Example: Perform actions based on the card played
    }
}

