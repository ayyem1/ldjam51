using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<Enemy> Enemies = new List<Enemy>();

    [SerializeField] private EnemyUISpawner enemyUISpawner;
    [SerializeField] private EnemyAI enemyAI;
    [SerializeField] private Timer timer;
    [SerializeField] private CardUI draggedCardUI;
    [SerializeField] private Transform popUpTransform;
    [SerializeField] private Sprite[] actionTypeSpriteArray;
    [SerializeField] private BattleDialog dialogBox;
    private Sprite sprite;

    public DeckController DeckController;

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

        DeckController.CreateHand(draggedCardUI);
        // TODO: Insert dialog.

        timer.SetTimer();
    }

    public PopUpAction CreatePopUp(float valueAmount, Card.ActionType actionType)
    {
        switch(actionType)
        {
            case Card.ActionType.Attack:
                sprite = actionTypeSpriteArray[0];
                break;
            case Card.ActionType.Defense:
                sprite = actionTypeSpriteArray[1];
                break;
            case Card.ActionType.BuffAttack:
                sprite = actionTypeSpriteArray[2];
                break;
            case Card.ActionType.BuffDefense:
                sprite = actionTypeSpriteArray[3];
                break;
            case Card.ActionType.DebuffAttack:
                sprite = actionTypeSpriteArray[4];
                break;
            case Card.ActionType.DebuffDefense:
                sprite = actionTypeSpriteArray[5];
                break;
            default:
                Debug.LogError("Wrong Action Type");
                break;
        }
        
        PopUpAction popUpAction = popUpTransform.GetComponent<PopUpAction>();
        popUpAction.Setup(valueAmount, sprite);
        return popUpAction;
    }

    public void RewardScreen()
    {
        timer.StopTimer();
        dialogBox.InitializeReward(GameInstance.Instance.SelectedEntity, true);
    }

    public void GameOverScreen()
    {
        timer.StopTimer();
        dialogBox.InitializeGameOver();
    }
}
