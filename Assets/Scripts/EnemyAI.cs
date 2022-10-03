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
            if(GameInstance.Instance.MainPlayer.CurrentHp <=0 )
            {
                GameManager.Instance.GameOverScreen();
            }
        }
    }

    private void TakeEnemyAIAction(Enemy enemy)
    {
        //Reset Defense
        enemy.ResetDefense();
        //Get Pattern
        Card.ActionType actionName = enemy.Data.movePattern[enemy.CurrentPatternIndex];
        //Take action
        Debug.Log("Action: " + actionName);

        List<EnemyUIV2> enemyUIList = GameManager.Instance.GetEnemyUISpawner().enemyEntityUIList;
        int enemyUIIndex = 0;

        //Find EnemyUI
        foreach (EnemyUIV2 possibleEnemyUI in enemyUIList)
        {
            if (possibleEnemyUI.GetEnemy() == enemy)
            {
                enemyUIIndex = enemyUIList.IndexOf(possibleEnemyUI);
            }
        }

        EnemyUIV2 enemyUI = enemyUIList[enemyUIIndex];
        
        switch(actionName)
        {
            case Card.ActionType.Attack:
                GameInstance.Instance.MainPlayer.Damage(enemy.CurrentDamageValue);
                GameManager.Instance.CreatePopUp(GameInstance.Instance.MainPlayer.transform, enemy.CurrentDamageValue, actionName, false);
                enemy.ResetBuffs();
                break;
            case Card.ActionType.Defense:
                enemy.ModifyDefense(enemy.CurrentDefenseIncrementValue);
                GameManager.Instance.CreatePopUp(enemyUI.transform, enemy.CurrentDamageValue, actionName, true);
                enemy.ResetBuffs();
                break;
            case Card.ActionType.BuffAttack:
                enemy.BuffDamage(enemy.DamageBuffAmount);
                GameManager.Instance.CreatePopUp(enemyUI.transform, enemy.DamageBuffAmount, actionName, true);
                break;
            case Card.ActionType.BuffDefense:
                enemy.BuffDefense(enemy.DefenseBuffAmount);
                GameManager.Instance.CreatePopUp(enemyUI.transform, enemy.DefenseBuffAmount, actionName, true);
                break;
            case Card.ActionType.DebuffAttack:
                GameInstance.Instance.MainPlayer.BuffDamage(-enemy.DebuffDamageAmount);
                GameManager.Instance.CreatePopUp(GameInstance.Instance.MainPlayer.transform, -enemy.DebuffDamageAmount, actionName, false);
                break;
            case Card.ActionType.DebuffDefense:
                GameInstance.Instance.MainPlayer.BuffDefense(-enemy.DebuffDefenseAmount);
                GameManager.Instance.CreatePopUp(GameInstance.Instance.MainPlayer.transform, -enemy.DebuffDefenseAmount, actionName, false);
                break;
            default:
                Debug.LogError("Wrong Action Type");
                break;
        }
        enemy.UpdatePatternIndex();
    }
}
