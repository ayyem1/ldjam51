using UnityEngine;

public class EntitySelection : MonoBehaviour
{
    [SerializeField] private Entity entity;
    public void GoToBattle()
    {
        GameInstance.Instance.StartBattle(entity);
    }
}
