using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<CardData> player1Deck; // List to hold player 1's deck
    public List<CardData> player2Deck; // List to hold player 2's deck

    public List<Card> player1Hand; // List to hold the cards in player 1's hand
    public List<Card> player2Hand; // List to hold the cards in player 2's hand

    public GameObject player1DeckPosition;
    public GameObject player2DeckPosition;

    public GameObject cardPrefab; // The card prefab
    public Transform player1HandPosition; // The position to place player 1's hand
    public Transform player2HandPosition; // The position to place player 2's hand

    public GameObject Player1Hand;
    public GameObject Player2Hand;

    // Start is called before the first frame update
    void Start()
    {

        GameObject Player1Hand = new GameObject("Player1Hand");
        GameObject Player2Hand = new GameObject("Player2Hand");

        // Initialize the hands
        player1Hand = new List<Card>();
        player2Hand = new List<Card>();
        
        // Load the decks
        LoadDeck(player1Deck, "Player1");
        LoadDeck(player2Deck, "Player2");

        // Display the decks
        DisplayDeck(player1Deck, player1DeckPosition.transform.position, 1); // Position for player 1's deck
        DisplayDeck(player2Deck, player2DeckPosition.transform.position, 2); // Position for player 2's deck
    }

    // Function to load a deck
    void LoadDeck(List<CardData> deck, string player)
    {
        // Load the cards from the scriptable objects into the deck
        CardData[] cards = Resources.LoadAll<CardData>("CardData");
        foreach (CardData card in cards)
        {
            deck.Add(card);
        }
    }

    // Function to display a deck
    void DisplayDeck(List<CardData> deck, Vector3 startPosition, int player)
    {
        // Create a new parent object for the deck
        GameObject deckParent = new GameObject("Player" + player + "Deck");

        // Instantiate and position the cards in the deck
        for (int i = 0; i < deck.Count; i++)
        {
            // Instantiate a new card object and rotate it to face down
            GameObject card = Instantiate(cardPrefab, startPosition + new Vector3(0, i * 0.05f, 0), Quaternion.Euler(-90, 0, 0));

            // Set the card's data
            card.GetComponent<Card>().cardData = deck[i];

            // Set the card as a child of the deck parent
            card.transform.parent = deckParent.transform;

            // Set the Card Objects Name
            card.transform.name = "Player" + player + "_Card_" + i;

            // Set the Cards Player
            card.GetComponent<Card>().player = player;
        }
    }

    public void DrawCard(List<CardData> deck, int player)
    {
        if (deck == null) return;

        // Check if there are cards left in the deck
        if (deck.Count > 0)
        {
            // Remove a card from the deck
            CardData cardData = deck[0];
            deck.RemoveAt(0);

            // Instantiate a new card object
            GameObject card = Instantiate(cardPrefab, player == 1 ? player1HandPosition.position : player2HandPosition.position, Quaternion.identity);
            card.transform.Rotate(-90, 0, 0); // Rotate the card to face down

            // Set the card's data
            Card cardComponent = card.GetComponent<Card>();
            cardComponent.cardData = cardData;
            cardComponent.player = player; // Set the player variable

            // Add the card to the player's hand
            if (player == 1)
            {
                player1Hand.Add(cardComponent);
                //cardComponent.transform.parent = Player1Hand.transform;
            }
            else
            {
                player2Hand.Add(cardComponent);
                //card.transform.parent = Player2Hand.transform;
            }
        }
    }

}
