using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<Enemy> Enemies = new List<Enemy>();

    [SerializeField] private EnemyUISpawner enemyUISpawner;
    [SerializeField] private EnemyAI enemyAI;
    [SerializeField] private Timer timer;

    public void Start()
    {
        var activeEntity = GameInstance.Instance.SelectedEntity;
        foreach (Entity minion in activeEntity.minions)
        {
            Enemies.Add(new Enemy(minion));
        }
        int mid = Enemies.Count / 2;
        Enemies.Insert(mid, new Enemy(activeEntity));

        enemyUISpawner.SpawnEnemyUI(Enemies);
        enemyAI.Initialize(Enemies);

        // TODO: Insert dialog.

        timer.SetTimer();
    }
}
