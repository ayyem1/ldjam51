using UnityEngine;

[CreateAssetMenu(fileName = "NewTreasure", menuName = "ScriptableObjects/Treasure", order = 1)]
public class Treasure : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Icon;
    public int GrantedCorporateBucks;
    public Card[] GrantedCards;
}
