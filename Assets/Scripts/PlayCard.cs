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

    }
}
