using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrop : MonoBehaviour, IDropHandler
{
    public enum DropLocation
    {
        Deck,
        Reserves
    }
    public DropLocation Location;
    public DeckBuilderDialog Dialog;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }
        
        var draggedCardUI = eventData.pointerDrag.GetComponent<CardDrag>();
        if (!draggedCardUI.CardUIData.transform.IsChildOf(transform) && IsDropAllowed(draggedCardUI))
        {
            // Check if deck can be reduced or added to.
            // Update Player data.
            if (Location == DropLocation.Deck)
            {
                GameInstance.Instance.MainPlayer.CardsInDeck.Add(draggedCardUI.DraggedCardUI.Data);
                GameInstance.Instance.MainPlayer.ReserveCards.Remove(draggedCardUI.DraggedCardUI.Data);
            }
            else
            {
                GameInstance.Instance.MainPlayer.ReserveCards.Add(draggedCardUI.DraggedCardUI.Data);
                GameInstance.Instance.MainPlayer.CardsInDeck.Remove(draggedCardUI.DraggedCardUI.Data);
            }

            // Update dialog with new card instance.
            Dialog.AddNewCardDataToContent(Location, draggedCardUI.DraggedCardUI.Data);

            // Nuke pointer data so that CardDrag::OnEndDrag doesn't get called.
            eventData.pointerDrag = null;
            draggedCardUI.ResetDragContainer();

            // Destroy old card instance.
            Destroy(draggedCardUI.gameObject);
        }
    }

    private bool IsDropAllowed(CardDrag draggedCardUI)
    {
        if (Location == DropLocation.Deck && GameInstance.Instance.MainPlayer.CardsInDeck.Count >= GameInstance.Instance.MainPlayer.MaxDeckCount)
        {
            return false;
        }
        else if (Location == DropLocation.Reserves && GameInstance.Instance.MainPlayer.CardsInDeck.Count <= GameInstance.Instance.MainPlayer.MinDeckCount)
        {
            return false;
        }

        return true;
    }
}
