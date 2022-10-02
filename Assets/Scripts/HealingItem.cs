using UnityEngine;

[CreateAssetMenu(fileName = "NewHealingItem", menuName = "ScriptableObjects/Healing Item", order = 1)]
public class HealingItem : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Icon;
    [Min(0f)] public float HealingAmount;
    [Min(0f)] public int HealingPrice;
}
