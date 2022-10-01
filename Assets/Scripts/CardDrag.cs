using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
// This drag implementation relies on a drag container be set up outside of the grid to avoid
// sort order collisions with the items in the grid. The drag container needs to have
// Image and CanvasGroup components. The CanvasGroup on the drag container needs to disable
// 'blocks raycasts' and can optionally have an alpha value less than 1.
public class CardDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public CardUI cardUI;

    private Camera uiCamera;
    private float offsetY;
    private float offsetX;
    private Vector3 initialPosition;
    public CardUI DraggedCardUI { get; private set; }

    // These handlers hook into the events exposed in UIDataItem
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (cardUI == null || cardUI.IsEmpty)
        {
            // Cancel the drag if we are trying to drag an empty equipment item.
            eventData.pointerDrag = null;
            return;
        }

        initialPosition = transform.position;
        var pointerInWorldPos = uiCamera.ScreenToWorldPoint(eventData.position);
        offsetX = pointerInWorldPos.x - initialPosition.x;
        offsetY = pointerInWorldPos.y - initialPosition.y;

        // Set drag container canvas group params
        DraggedCardUI.gameObject.transform.position = initialPosition;
        DraggedCardUI.Initialize(cardUI.Data);
        DraggedCardUI.gameObject.SetActive(true);

        // Disable icon on mergeable item.
        cardUI.Clear();
        //cardUI.imageIcon.sprite = null;
        //cardUI.imageIcon.color = Color.clear;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var pointerInWorldPos = uiCamera.ScreenToWorldPoint(eventData.position);
        DraggedCardUI.gameObject.transform.position = new Vector3(pointerInWorldPos.x - offsetX, pointerInWorldPos.y - offsetY, initialPosition.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Note: This is very closely tied to MergeDrag.OnDrop. The code there can short-circuit the call to this
        // by setting eventData.pointerDrag to null.
        Reset();
    }

    private void Reset()
    {
        cardUI.Initialize(DraggedCardUI.Data);
        //cardUI.imageIcon.sprite = DraggedCardUI.sprite;
        //cardUI.imageIcon.color = Color.white;
        ResetDragContainer();
    }

    public void ResetDragContainer()
    {
        DraggedCardUI.gameObject.SetActive(false);
        DraggedCardUI.Clear();
    }

    private void Start()
    {
        DraggedCardUI = GameObject.FindGameObjectWithTag("DraggedCardUI").GetComponent<CardUI>();
        DraggedCardUI.gameObject.SetActive(false);

        var uiCameraObject = Camera.main;//GameObject.FindGameObjectWithTag("UICamera");
        if (uiCameraObject == null)
        {
            Debug.LogError("No uiCamera found in scene. This will result in errors for the drag.");
        }
        else
        {
            uiCamera = uiCameraObject.GetComponent<Camera>();
        }
    }
}
