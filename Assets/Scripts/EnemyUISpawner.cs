using System.Collections.Generic;
using UnityEngine;

public class EnemyUISpawner : MonoBehaviour
{
    [SerializeField] private EnemyUI enemyPrefab;
    [SerializeField] private Transform enemyContainerTransform;

    public void SpawnEnemyUI(List<Enemy> enemies)
    {
        foreach (Transform enemyTransform in enemyContainerTransform)
        {
            Destroy(enemyTransform.gameObject);
        }

        foreach (Enemy enemy in enemies)
        {
            EnemyUI enemyEntityUI = Instantiate<EnemyUI>(enemyPrefab, enemyContainerTransform);
            enemyEntityUI.Initialize(enemy);
        }
    }
}