using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
    public Color cardColor;
    public string cardDescription;
}
