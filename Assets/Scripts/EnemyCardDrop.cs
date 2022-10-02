using Unity.VisualScripting;
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

        if (cardToPlay.cardActionType == Card.ActionType.Attack)
        {
            enemyUI.GetEnemy().Damage(cardToPlay.cardValue + mainPlayer.BuffDamageAmount);
        }
        else if (cardToPlay.cardActionType == Card.ActionType.Defense)
        {
            mainPlayer.ModifyDefense(cardToPlay.cardValue + mainPlayer.BuffDefenseAmount);
        }
        else if (cardToPlay.cardActionType == Card.ActionType.BuffAttack)
        {
            mainPlayer.BuffDamage(cardToPlay.cardValue);
        }
        else if (cardToPlay.cardActionType == Card.ActionType.BuffDefense)
        {
            mainPlayer.BuffDefense(cardToPlay.cardValue);
        }
        else if (cardToPlay.cardActionType == Card.ActionType.DebuffAttack)
        {
            enemyUI.GetEnemy().BuffDamage(-cardToPlay.cardValue);
        }
        else if (cardToPlay.cardActionType == Card.ActionType.DebuffDefense)
        {
            enemyUI.GetEnemy().BuffDefense(-cardToPlay.cardValue);
        }

        // Draw Next Card
        GameManager.Instance.DeckController.DrawCard();

        // If object is dropped on an enemy and is an attack
        // Then damage enemy, place card in discard pile, draw next card, destroy card
        if(GameInstance.Instance.MainPlayer.GetMana() == 0)
        {
            mainPlayer.ResetBuffs();
            TurnSystem.Instance.NextTurn();
        }
    }
}
