using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Entity currentEntity;
    private List<Enemy> enemyList;
   
    private void Start()
    {
        TurnSystem.Instance.OnTurnChanged -= TurnSystem_OnTurnChanged;
        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;
    }

    public void Initialize(List<Enemy> enemies)
    {
        enemyList = enemies;
    }

    private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
    {
        if (TurnSystem.Instance.IsPlayerTurn())
        {
            return;
        }

        StartCoroutine(DoEnemyTurn(2f));
    }

    private IEnumerator DoEnemyTurn(float startDelay)
    {
        yield return new WaitForSeconds(startDelay);
        TakeEnemyAIAction();
        TurnSystem.Instance.NextTurn();
    }

    private void TakeEnemyAIAction()
    {
        foreach (Enemy enemy in enemyList)
        {
            //Debug.Log("Enemy: " + enemy.Data.Name);
            TakeEnemyAIAction(enemy);
        }
    }

    private void TakeEnemyAIAction(Enemy enemy)
    {
        //Reset Defense
        enemy.ResetDefense();
        //Get Pattern
        Entity.ActionType actionName = enemy.Data.movePattern[enemy.CurrentPatternIndex];
        //Take action
        Debug.Log("Action: " + actionName);
        
        switch(actionName)
        {
            case Entity.ActionType.Attack:
                GameInstance.Instance.MainPlayer.Damage(enemy.CurrentDamageValue);
                enemy.ResetBuffs();
                break;
            case Entity.ActionType.Defense:
                enemy.ModifyDefense(enemy.CurrentDefenseIncrementValue);
                enemy.ResetBuffs();
                break;
            case Entity.ActionType.BuffAttack:
                enemy.BuffDamage(enemy.DamageBuffAmount);
                break;
            case Entity.ActionType.BuffDefense:
                enemy.BuffDefense(enemy.DefenseBuffAmount);
                break;
            case Entity.ActionType.DebuffAttack:
                GameInstance.Instance.MainPlayer.BuffDamage(-enemy.DebuffDamageAmount);
                break;
            case Entity.ActionType.DebuffDefense:
                GameInstance.Instance.MainPlayer.BuffDefense(-enemy.DebuffDefenseAmount);
                break;
            default:
                Debug.LogError("Wrong Action Type");
                break;
        }
        enemy.UpdatePatternIndex();
    }
}
