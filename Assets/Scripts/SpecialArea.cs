using UnityEngine;

[CreateAssetMenu(fileName = "NewSpecialArea", menuName = "ScriptableObjects/Special Area", order = 1)]
public class SpecialArea : ScriptableObject
{
    public enum AreaType
    {
        Healing,
        Shop
    }

    public string Name;
    public AreaType Type;
    [Min(0f)] public float HealingAmount;
    [Min(0f)] public int HealingPrice;
    // TODO: Items to purchase.
}
