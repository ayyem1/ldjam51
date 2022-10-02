using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        WaitingForEnemyTurn,
        TakingTurn,
        Busy
    }
    
    private State state;
    private float enemyTimer;
    [SerializeField] private Entity currentEntity;
    private List<Entity> enemyList;
    
    private void Awake()
    {
        state = State.WaitingForEnemyTurn;
        enemyList = new List<Entity>{currentEntity};
        foreach (Entity minion in currentEntity.minions)
        {
            enemyList.Add(minion);   
        }
        enemyList.Reverse();
    }
    private void Start()
    {
        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;
    }
    private void Update()
    {
        if (TurnSystem.Instance.IsPlayerTurn())
        {
            return;
        }

        Debug.Log("Enemy Turn: " + enemyList.Count);
        Debug.Log("State: " + state);
        switch(state)
        {
            case State.WaitingForEnemyTurn:
                Debug.Log("WaitingForTurn");
                break;
            case State.TakingTurn:
                enemyTimer -= Time.deltaTime;
                Debug.Log("Taking Turn: "+ enemyTimer);
                if (enemyTimer <= 0f)
                {
                    TryTakeEnemyAIAction(SetStateTakingTurn);
                    TurnSystem.Instance.NextTurn();
                }
                break;
            case State.Busy:
                break;
        }
    }

    private void SetStateTakingTurn()
    {
        enemyTimer = 0.5f;
        state = State.TakingTurn;
    }

    private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
    {
        if (!TurnSystem.Instance.IsPlayerTurn())
        {
            state = State.TakingTurn;
            enemyTimer = 2f;
        }
    }

    private void TryTakeEnemyAIAction(Action onEnemyAIActionComplete)
    {
        foreach (Entity enemy in enemyList)
        {
            Debug.Log("Enemy: " + enemy.Name);
            TryTakeEnemyAIAction(enemy, onEnemyAIActionComplete);
        }

    }

    private void TryTakeEnemyAIAction(Entity enemy, Action onEnemyAIActionComplete)
    {
        //Get Pattern
        Entity.ActionType actionName = enemy.movePattern[enemy.CurrentPatternIndex];
        //Take action
        Debug.Log("Action: " + actionName);
        
        switch(actionName)
        {
            case Entity.ActionType.Attack:
                GameInstance.Instance.MainPlayer.Damage(enemy.CurrentDamageValue);
                break;
            case Entity.ActionType.Defense:
                enemy.ModifyDefense(enemy.CurrentDefenseIncrementValue);
                break;
            case Entity.ActionType.BuffAttack:
                enemy.buffDamage();
                break;
            case Entity.ActionType.BuffDefense:
                enemy.buffDefense();
                break;
            case Entity.ActionType.DebuffAttack:
                // Add Logic
                break;
            case Entity.ActionType.DebuffDefense:
                // Add Logic
                break;
            default:
                Debug.LogError("Wrong Action Type");
                break;
        }
        enemy.UpdatePatternIndex();
    }
}
