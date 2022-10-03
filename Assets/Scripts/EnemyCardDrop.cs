using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyCardDrop : MonoBehaviour, IDropHandler
{
    [SerializeField] private EnemyUIV2 enemyUI;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        var cardDragComponent = eventData.pointerDrag.GetComponent<CardDrag>();
        var draggedCardData = cardDragComponent.DraggedCardUI.Data;
        if (IsDropAllowed())
        {
            PlayCard(cardDragComponent.DraggedCardUI.Data);
            // Nuke pointer data so that CardDrag::OnEndDrag doesn't get called.
            eventData.pointerDrag = null;
            cardDragComponent.ResetDragContainer();

            // Destroy old card instance.
            GameManager.Instance.DeckController.UseCard(cardDragComponent.CardUIData, draggedCardData);
            //Destroy(cardDragComponent.gameObject);
        }
    }

    private bool IsDropAllowed()
    {
        return GameInstance.Instance.MainPlayer.RemainingPlayerMana > 0;
    }

    private void PlayCard(Card cardToPlay)
    {
        Player mainPlayer = GameInstance.Instance.MainPlayer;
        mainPlayer.ReduceMana(1); // We currently assume each card played requires 1 mana.
        Card.ActionType actionName = cardToPlay.cardActionType;
        switch(actionName)
        {
            case Card.ActionType.Attack:
                enemyUI.GetEnemy().Damage(cardToPlay.cardValue + mainPlayer.BuffDamageAmount);
                GameManager.Instance.CreatePopUp(cardToPlay.cardValue + mainPlayer.BuffDamageAmount, actionName);
                break;
            case Card.ActionType.Defense:
                mainPlayer.ModifyDefense(cardToPlay.cardValue + mainPlayer.BuffDefenseAmount);
                GameManager.Instance.CreatePopUp(cardToPlay.cardValue + mainPlayer.BuffDefenseAmount, actionName);
                break;
            case Card.ActionType.BuffAttack:
                mainPlayer.BuffDamage(cardToPlay.cardValue);
                GameManager.Instance.CreatePopUp(cardToPlay.cardValue, actionName);
                break;
            case Card.ActionType.BuffDefense:
                mainPlayer.BuffDefense(cardToPlay.cardValue);
                GameManager.Instance.CreatePopUp(cardToPlay.cardValue, actionName);
                break;
            case Card.ActionType.DebuffAttack:
                enemyUI.GetEnemy().BuffDamage(-cardToPlay.cardValue);
                GameManager.Instance.CreatePopUp(cardToPlay.cardValue, actionName);
                break;
            case Card.ActionType.DebuffDefense:
                enemyUI.GetEnemy().BuffDefense(-cardToPlay.cardValue);
                GameManager.Instance.CreatePopUp(cardToPlay.cardValue, actionName);
                break;
            default:
                Debug.LogError("Wrong Action Type");
                break;
        }

        GameManager.Instance.DeckController.DrawCard();

        if(enemyUI.GetEnemy().CurrentHp <= 0)
        {
            GameManager.Instance.Enemies.Remove(enemyUI.GetEnemy());
        }

        if(GameManager.Instance.Enemies.Count == 0)
        {
            GameManager.Instance.RewardScreen();
        }

        if(GameInstance.Instance.MainPlayer.GetMana() == 0)
        {
            TurnSystem.Instance.NextTurn();
        }
    }
}
