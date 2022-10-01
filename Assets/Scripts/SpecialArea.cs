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
    public float HealingAmount;
    public float HealingPrice;
    // TODO: Items to purchase.
}
