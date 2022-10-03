using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "ScriptableObjects/Card", order = 1)]
public class Card : ScriptableObject
{
    public string Title;
    public string Description;
    public Sprite Icon;
    public ActionType cardActionType;

    public enum ActionType
    {
        Attack,
        Defense,
        BuffAttack,
        BuffDefense,
        DebuffAttack,
        DebuffDefense
    }
    public float cardValue;
    public Buff[] Buffs;
}
