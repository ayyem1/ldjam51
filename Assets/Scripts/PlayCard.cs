using UnityEngine;

public class PlayCard : MonoBehaviour
{
    // Add this script to the moveable object
    public RectTransform rectTransform;
    private CardUI cardUI;
    Vector3 offset;
    public void GetOffset()
    {
        offset = rectTransform.position - Input.mousePosition;
    }
    public void MoveObject()
    {
        rectTransform.position = Input.mousePosition + offset;
    }

    public void DropObject()
    {
        CardUI thisCard = gameObject.GetComponent<CardUI>();
        Debug.Log("Dropped Card at " + rectTransform.position);
        Debug.Log("Card Type: " + thisCard.Data.cardActionType);
        //Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity);
        Collider2D hitCollider = Physics2D.OverlapBox(gameObject.transform.position,transform.localScale,0f);
        
        //Check when there is a new collider coming into contact with and Enemy
        if(hitCollider.CompareTag("Enemy"))
        {
            if (thisCard.Data.cardActionType == Card.ActionType.Attack)
            {
                EnemyUI enemyUI = hitCollider.gameObject.GetComponent<EnemyUI>();
                enemyUI.GetEnemy().Damage(thisCard.Data.cardValue);
            }
            else if (thisCard.Data.cardActionType == Card.ActionType.Defense)
            {
                GameInstance.Instance.MainPlayer.ModifyDefense(thisCard.Data.cardValue);
            }
            else if (thisCard.Data.cardActionType == Card.ActionType.Buff)
            {
                // Add Buff Logic
            }
            
            // Place Card in Discard Pile
            // Destroy Card Object
            // Draw Next Card

        }
        // If object is dropped on an enemy and is an attack
        // Then damage enemy, place card in discard pile, draw next card, destroy card
    }
}
