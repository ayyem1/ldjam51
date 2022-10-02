using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private EntityUI enemyPrefab;
    [SerializeField] private Transform enemyContainerTransform;
    private List<Entity> spawnEntities;

    private void Start()
    {
        CreateEnemies();
    }
    private void CreateEnemies()
    {
        var activeEntity = GameInstance.Instance.SelectedEntity;
        foreach (Transform enemyTransform in enemyContainerTransform)
        {
            Destroy(enemyTransform.gameObject);
        }
        
        spawnEntities = new List<Entity>();
        foreach (Entity minion in activeEntity.minions)
        {
            spawnEntities.Add(minion);   
        }
        int mid = spawnEntities.Count/2;
        spawnEntities.Insert(mid, activeEntity);

        foreach (Entity enemy in spawnEntities)
        {
            EntityUI enemyEntity = Instantiate<EntityUI>(enemyPrefab, enemyContainerTransform);
            enemyEntity.InitializeEntity(enemy);
        }
    }

    public List<Entity> GetEnemiesList()
    {
        return spawnEntities;
    }

}