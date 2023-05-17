using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    private CardData _cardData; // Private field to hold the card data
    public int player;

    public CardData cardData // Public property to access the card data
    {
        get { return _cardData; } // Getter returns the private field
        set // Setter updates the private field and calls UpdateCardDisplay()
        {
            _cardData = value;
            UpdateCardDisplay();
        }
    }

    public Renderer frontQuadRenderer; // Reference to the Renderer component of the front quad
    public Image cardImage; // Reference to the Image component
    public TextMeshProUGUI cardName; // Reference to the TextMeshProUGUI component for the card name
    public TextMeshProUGUI cardDescription; // Reference to the TextMeshProUGUI component for the card description

    // Function to update the card display
    public void UpdateCardDisplay()
    {
        // Set the card image, name, and description based on the card data
        cardImage.sprite = cardData.cardImage;
        cardName.text = cardData.cardName;
        cardDescription.text = cardData.cardDescription;

        // Set the color of the front quad's material based on the card data
        frontQuadRenderer.material.color = cardData.cardColor;
    }
}
