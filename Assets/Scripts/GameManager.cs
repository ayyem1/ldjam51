using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public List<Enemy> Enemies = new List<Enemy>();

    [SerializeField] private EnemyUISpawner enemyUISpawner;
    [SerializeField] private EnemyAI enemyAI;
    [SerializeField] private Timer timer;
    [SerializeField] private CardUI draggedCardUI;
    [SerializeField] private Transform popUpTransform;
    [SerializeField] private Sprite[] spriteArray;
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
                sprite = spriteArray[0];
                break;
            case Card.ActionType.Defense:
                sprite = spriteArray[1];
                break;
            case Card.ActionType.BuffAttack:
                sprite = spriteArray[2];
                break;
            case Card.ActionType.BuffDefense:
                sprite = spriteArray[3];
                break;
            case Card.ActionType.DebuffAttack:
                sprite = spriteArray[4];
                break;
            case Card.ActionType.DebuffDefense:
                sprite = spriteArray[5];
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
        SceneManager.LoadScene(1);
    }

    public void GameOverScreen()
    {
        timer.StopTimer();
        SceneManager.LoadScene(0);
    }
}
