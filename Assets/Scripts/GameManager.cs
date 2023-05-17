using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables to keep track of the game state
    private bool startOfGame = true;
    private bool player1TurnEnded = false;
    private bool player2TurnEnded = false;
    private Card player1Card;
    private Card player2Card;

    public CardManager cardManager; // Reference to the DeckManager

    private int currentPlayer; // The current player (1 or 2)

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the current player to 1
        currentPlayer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for player input and handle player actions
        HandlePlayerActions();

        // Check for win conditions
        CheckWinConditions();
    }

    // Function to handle player actions
    void HandlePlayerActions()
    {
        // At the start of the game, each player draws 3 cards
        if (startOfGame)
        {
            for (int i = 0; i < 3; i++)
            {
                cardManager.DrawCard(cardManager.player1Deck,1);
                cardManager.DrawCard(cardManager.player2Deck,2);
            }
            startOfGame = false;
        }

    // If the player clicks on a card in their hand, play it
    if (Input.GetMouseButtonDown(0))
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Card card = hit.transform.GetComponent<Card>();
            if (card != null)
            {
                // Check which player's card was clicked and set it as their chosen card for the round
                if (card.player == 1 && !player1TurnEnded)
                {
                    player1Card = card;
                }
                else if (card.player == 2 && !player2TurnEnded)
                {
                    player2Card = card;
                }
            }
        }
    }

    // If the player clicks the end turn button, mark their turn as ended
    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (!player1TurnEnded)
        {
            player1TurnEnded = true;
        }
        else if (!player2TurnEnded)
        {
            player2TurnEnded = true;
        }

        // If both players have ended their turn, compare the cards and start a new round
        if (player1TurnEnded && player2TurnEnded)
        {
            CompareCards();
            StartNewRound();
        }
    }
    }

    // Function to compare the cards and determine the winner of the round
    void CompareCards()
    {
        // Compare the cards
        // This will depend on the rules of your game
    }

    // Function to start a new round
    void StartNewRound()
    {
        // Reset the turn ended flags
        player1TurnEnded = false;
        player2TurnEnded = false;

        // Each player draws a card
        cardManager.DrawCard(cardManager.player1Deck,1);
        cardManager.DrawCard(cardManager.player2Deck,2);
    }


    // Function to check for win conditions
    void CheckWinConditions()
    {
        // Check for win conditions and handle winning the game
        // This could include checking if a player's deck is empty, if a player's health is 0, etc.
    }

    // Function to switch to the other player
    void SwitchPlayer()
    {
        // Switch to the other player
        currentPlayer = 3 - currentPlayer;
    }
}
