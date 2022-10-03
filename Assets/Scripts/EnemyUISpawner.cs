using System.Collections.Generic;
using UnityEngine;

public class EnemyUISpawner : MonoBehaviour
{
    [SerializeField] private EnemyUIV2 enemyPrefab;
    [SerializeField] private Transform enemyContainerTransform;

    public List<EnemyUIV2> enemyEntityUIList = new List<EnemyUIV2>();

    public void SpawnEnemyUI(List<Enemy> enemies)
    {
        foreach (Transform enemyTransform in enemyContainerTransform)
        {
            Destroy(enemyTransform.gameObject);
        }

        foreach (Enemy enemy in enemies)
        {
            EnemyUIV2 enemyEntityUI = Instantiate<EnemyUIV2>(enemyPrefab, enemyContainerTransform);
            enemyEntityUI.Initialize(enemy);
            enemyEntityUIList.Add(enemyEntityUI);
        }
    }
}