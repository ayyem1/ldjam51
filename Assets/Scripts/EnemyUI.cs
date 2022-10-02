using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private EntityUI enemyPrefab;
    [SerializeField] private Transform enemyContainerTransform;
    [SerializeField] private Entity currentEntity;
    private List<EntityUI> enemyUIList;
    private List<Entity> spawnEntities;

    private void Start()
    {
        CreateEnemies();
    }
    private void Update()
    {
        foreach (EntityUI enemyUI in enemyUIList)
        {
            enemyUI.UpdateEntityVisual();
        }
    }
    private void CreateEnemies()
    {
        foreach (Transform enemyTransform in enemyContainerTransform)
        {
            Destroy(enemyTransform.gameObject);
        }
        
        spawnEntities = new List<Entity>();
        foreach (Entity minion in currentEntity.minions)
        {
            spawnEntities.Add(minion);   
        }
        int mid = spawnEntities.Count/2;
        spawnEntities.Insert(mid, currentEntity);

        enemyUIList = new List<EntityUI>();
        foreach (Entity enemy in spawnEntities)
        {
            EntityUI enemyEntity = Instantiate<EntityUI>(enemyPrefab, enemyContainerTransform);
            enemyEntity.InitializeEntity(enemy);
            enemyUIList.Add(enemyEntity);
        }
    }

    public List<Entity> GetEnemiesList()
    {
        return spawnEntities;
    }



}