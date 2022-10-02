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
    private List<Entity> enemyList;
    private EnemyUI enemyUI;
    private int patternIndex = 1;
    
    private void Awake()
    {
        state = State.WaitingForEnemyTurn;
        enemyList = enemyUI.GetEnemiesList();
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

        switch(state)
        {
            case State.WaitingForEnemyTurn:
                break;
            case State.TakingTurn:
                enemyTimer -= Time.deltaTime;
                if (enemyTimer <= 0f)
                {
                    if (TryTakeEnemyAIAction(SetStateTakingTurn))
                    {
                        state = State.Busy;
                    }
                    else
                    {
                        // No more enemies have actions they can take, end enemy turn
                        TurnSystem.Instance.NextTurn();
                    }
                    
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

    private bool TryTakeEnemyAIAction(Action onEnemyAIActionComplete)
    {
        foreach (Entity enemy in enemyList)
        {
            if(TryTakeEnemyAIAction(enemy, onEnemyAIActionComplete))
            {
                return true;
            }
        }

        return false;
    }

    private bool TryTakeEnemyAIAction(Entity enemy, Action onEnemyAIActionComplete)
    {
        //Get Pattern
        //Take action
        //Update pattern index
                
        //If true, take action and return true, if no action taken, return false
        if (true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
